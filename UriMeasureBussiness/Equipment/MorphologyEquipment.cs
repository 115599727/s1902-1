using Medicside.UriMeasure.Bussiness.Camera;
using Medicside.UriMeasure.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
    /// <summary>
    /// 形态学检测仪器
    /// </summary>
   public class MorphologyEquipment : Equipment,IMorphplogyMeasure
    {


        public MorphologyEquipment()
        {
            this.Port232 = new PortRS232();
            Port232.PortName = "COM3";
            Port232.StopBites = 1;
            Port232.DataBits = 8;
            Port232.BaudRate = "115200";
            this.PortNet = new PortNetWork();
            pcHelper = new PortControlHelper(PortControlHelper.TransDataType.BytesData);
           
        }
        /// <summary>
        /// 串口设备端口
        /// </summary>
        public PortRS232 Port232
        {
            get;
            set;
        }

        /// <summary>
        /// 网口设备
        /// </summary>
        public PortNetWork PortNet
        {
                get;
                set;
        }


        /// <summary>
        /// 串口操作类
        /// </summary>
        PortControlHelper pcHelper;

        /// <summary>
        /// 聚焦
        /// </summary>
        /// <returns></returns>
        public int Focus()
        {
            return 0;
        }

        /// <summary>
        /// 空白测试
        /// </summary>
        /// <returns></returns>
        public int BlankTest()
        {
            return 0;
        }

        /// <summary>
        /// 校准
        /// </summary>
        /// <returns></returns>
        public int CalibratHydrometer()
        {
            return 0;
        }


        /// <summary>
        /// 质控操作
        /// </summary>
        /// <returns></returns>
        public int QC()
        {
            return 0;
        }
        /// <summary>
        /// 执行检测
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        public Dictionary<string, string> Measure(object sample)
        {
            try
            {
                IGrabImage balser = new BalserA1440OverlappedGrab("c:\\acA1440-220um_40021038.pfs");

                Thread th1 = new Thread(balser.GrabImage);
                th1.Priority = ThreadPriority.Highest;
                th1.IsBackground = false;
                th1.Start();

                Thread th = new Thread(SendShot);
                th.Priority = ThreadPriority.Normal;
                th.Start();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
       public void SendShot()
        {
            Thread.Sleep(1000);
            this.SendCommand(MEquCommandName.Shot);

        }


        /// <summary>
        /// 命令字节码字典
        /// </summary>
        static Dictionary<MEquCommandName, string> CommandText = new Dictionary<MEquCommandName, string>()
        {
            { MEquCommandName.Shot,"02 30 38 31 38 30 30 30 34 30 30 43 38 30 37 44 38 41 39 44 39 0D 0A" },
            {MEquCommandName.Reset,"02 30 32 30 32 30 30 30 32 30 30 30 30 43 31 34 30 0D 0A" }
        };
        public enum MEquCommandName
        {
            Reset, Shot
        }
        private void ReceiveData(byte[] data)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 向端口发生命令
        /// </summary>
        /// <param name="commandName"></param>
        public void SendCommand(MEquCommandName commandName)
        {

            if (pcHelper.PortState == false)
            {
                pcHelper.ClosePort();
                //Thread.Sleep(10);
                //打开端口
                pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites,5000);
            }



            byte[] CmdBytes = GetShotCommand(commandName);

            pcHelper.SendBytesData(CmdBytes);
        }
        /// <summary>
        /// 获取命令的字节码
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        private byte[] GetShotCommand(MEquCommandName commandName)
        {
            string commstr = CommandText[commandName];
            var list = PortControlHelper.strToToHexByte(commstr);
            return list;
        }

        public void Close()
        {
            if (pcHelper.OnComReceiveBytesHandler != null)
            {
                pcHelper.OnComReceiveBytesHandler = null;
            }
            pcHelper.ClosePort();

        }

    }

}
