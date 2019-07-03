using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
  public  class PortControlHelper
    {
        #region 字段/属性/委托
        /// <summary>
        /// 串行端口对象
        /// </summary>
        private SerialPort sp;

        /// <summary>
        /// 串口接收数据委托
        /// </summary>
        public delegate void ComReceiveStringHandler(string data);
        public delegate void ComReceiveBytesHandler(byte[] data);

        public ComReceiveBytesHandler OnComReceiveBytesHandler = null;
        public ComReceiveStringHandler OnComReceiveStringHandler = null;
        /// <summary>
        /// 端口名称数组
        /// </summary>
        public string[] PortNameArr { get; set; }

        /// <summary>
        /// 串口通信开启状态
        /// </summary>
        public bool PortState { get; set; } = false;

        /// <summary>
        /// 编码类型
        /// </summary>
        public Encoding EncodingType { get; set; } = Encoding.ASCII;
        #endregion

        #region 方法
        public PortControlHelper(TransDataType dataType)
        {
            PortNameArr = SerialPort.GetPortNames();
            sp = new SerialPort();
            if (dataType == TransDataType.BytesData)
            {
                sp.DataReceived += new SerialDataReceivedEventHandler(BytesReceived);
            }
            else
            {
                sp.DataReceived += new SerialDataReceivedEventHandler(StringReceived);
            }

        }

        public enum TransDataType { BytesData, StringData }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="portName">端口名称</param>
        /// <param name="boudRate">波特率</param>
        /// <param name="dataBit">数据位</param>
        /// <param name="stopBit">停止位</param>
        /// <param name="timeout">超时时间</param>
        public void OpenPort(string portName, int boudRate = 115200, int dataBit = 8, int stopBit = 1, int timeout = 5000)
        {
            if (PortState == true)
            {
                throw new Exception(portName + "已处于打开状态");
            }
            try
            {
                sp.PortName = portName;
                sp.BaudRate = boudRate;
                sp.DataBits = dataBit;
                sp.StopBits = (StopBits)stopBit;
                sp.ReadTimeout = timeout;
                sp.Open();
                PortState = true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePort()
        {
            try
            {
                sp.Close();
                PortState = false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sendData"></param>
        public void SendStringData(string sendData)
        {
            try
            {
                sp.Encoding = EncodingType;
                sp.Write(sendData);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SendBytesData(byte[] sendData)
        {
            try
            {

                sp.Write(sendData, 0, sendData.Length);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 接收数据回调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StringReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[sp.BytesToRead];
            sp.Read(buffer, 0, buffer.Length);
            string str = EncodingType.GetString(buffer);
            if (OnComReceiveStringHandler != null)
            {
                OnComReceiveStringHandler(str);
            }
        }
        private void BytesReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (this)
            {
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);

                if (OnComReceiveBytesHandler != null)
                {
                    OnComReceiveBytesHandler(buffer);
                }
            }

        }
        #endregion


        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += "0";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public static string[] GetComPorts()
        {
           var portArr = SerialPort.GetPortNames();
            return portArr;
        }
        /// <summary>
        /// 端口是否已连接
        /// </summary>
        /// <param name="portName">端口号</param>
        /// <returns></returns>
        public static bool IsPortConnected(string portName)
        {
            var portArr = SerialPort.GetPortNames();
            if (portArr.Length == 0)
                return false;
            foreach (var item in portArr)
            {
                if (item.Equals(portName))
                {
                    return true;
                }
            }
            
            return false;
        }

    }
}
