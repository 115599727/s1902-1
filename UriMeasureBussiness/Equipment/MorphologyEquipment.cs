using Medicside.UriMeasure.Bussiness.Camera;
using Medicside.UriMeasure.Bussiness.Interface;
using Medicside.UriMeasure.Bussiness.Recognition;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
    /// <summary>
    /// 形态学检测仪器
    /// </summary>
    public class MorphologyEquipment : Equipment, IMorphplogyMeasure
    {
        MorphologyEquipmentCommandBuilder MECommandBuilder;

        static int PortTimeOut = 5000;
        int shotImageWidthpx = 1440;
        int shotImageHeightpx = 1080;
        public MorphologyEquipment()
        {
            this.Port232 = new PortRS232();
            Port232.PortName = "COM1";
            Port232.StopBites = 1;
            Port232.DataBits = 8;
            Port232.BaudRate = "115200";
            this.PortNet = new PortNetWork();
            pcHelper = new PortControlHelper(PortControlHelper.TransDataType.BytesData);
            balser = new BalserA1440OverlappedGrab("c:\\acA1440-220um_40021038.pfs", "Basler acA1440-220um (40021038)");
            MECommandBuilder = new MorphologyEquipmentCommandBuilder();
            pcHelper.OnComReceiveBytesHandler += new PortControlHelper.ComReceiveBytesHandler(ReceiveData);
        }
        IGrabImage balser;
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

                Thread th1 = new Thread(balser.GrabImage);
                th1.Priority = ThreadPriority.Highest;
                th1.IsBackground = false;
                th1.Start();

                Thread th = new Thread(SendShot);
                th.Priority = ThreadPriority.Normal;
                th.Start();

                th1.Join();
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
            { MEquCommandName.Reset,"02 30 32 30 32 30 30 30 32 30 30 30 30 43 31 34 30 0D 0A" }
        };
        public enum MEquCommandName
        {
            Reset, Shot
        }
        public List<byte> ReceivedByteData = new List<byte>();
        private void ReceiveData(byte[] data)
        {
            ReceivedByteData.AddRange(data);
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
                pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);
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

        //相机连接测试操作
        public bool CameraConnctionTest()
        {
            return balser.IsCameraConnected();
        }

        /// <summary>
        /// 仪器的初始化检查
        /// </summary>
        /// <returns></returns>
        public bool EquipmentSetup()
        {
            //镜头连接
            if (CameraConnctionTest() != true)
            {
                return false;
            }
            //仪器端口通讯连接
            if (EquipmentPortIsConnected() != true)
            {
                return false;
            }
            //仪器复位
            if(EquReset()!=true)
            {
                return false;
            }
            return true;
        }
        //仪器连接测试
        public bool EquipmentPortIsConnected()
        {

            if (PortControlHelper.IsPortConnected(Port232.PortName) != true)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //仪器调节灰度
        public bool EquipmentAdjectGrayLeve()
        {
            int shotCount = 50;
            double grayValue = 0;
            double graySteps = 0;

            //  do
            //   {

            balser.SetNUM_GRABS = shotCount;

            Thread tgrab = new Thread(balser.GrabImage);
            tgrab.Priority = ThreadPriority.Highest;
            tgrab.Start();

            Thread.Sleep(800);

            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.GetShotCommand(200, shotCount);
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);

            tgrab.Join();

            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            pcHelper.ClosePort();
            if (result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishNoneValue] == null)
            {
                return false;
            }
            int n = balser.ResultImageList.Count;
            if(n!=shotCount)
            { return false; }
            int size = shotImageWidthpx * shotImageHeightpx;
            byte[] picData = new byte[size * shotCount];
            for (int i = 0; i < balser.ResultImageList.Count; i++)
            {
                Array.Copy(balser.ResultImageList[i].Buffer, 0, picData, i * size, size);
            }

            BitmapReader.GrayLevelAdjest(picData, shotImageWidthpx, shotImageHeightpx, n, ref grayValue, ref graySteps);
            balser.ResultImageList.Clear();
            int curFlashVol = FlashGetVol();

            Console.WriteLine("{0}     {1}", graySteps, curFlashVol);
            int setp = 0;
            if (int.TryParse(graySteps.ToString(), out setp))
            {
                if (graySteps > 0)
                {
                    FlashDecVol(Math.Abs(42));
                }
                else
                {
                    FlashAddVol(Math.Abs(42));
                }
            }
           
            // } while (graySteps==0);

            {
                return true;
            }



        }

        /// <summary>
        /// 空白测试
        /// </summary>
        /// <returns></returns>
        public bool EquipmentblankMeasure()
        {

            int shotCount = 2000;
            double grayValue = 0;
            double graySteps = 0;

            

            

            

            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.BlankMeasure();
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);
            //Thread.Sleep(18000);
            balser.SetNUM_GRABS = shotCount;
            Thread tgrab = new Thread(balser.GrabImage);
            tgrab.Priority = ThreadPriority.Highest;
            tgrab.Start();

            tgrab.Join();

            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            pcHelper.ClosePort();
            if (result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishNoneValue] == null)
            {
                return false;
            }
            int n = balser.ResultImageList.Count;
            if (n != shotCount)
            { return false; }
            return true;
        }

        string GetReceivedData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ReceivedByteData)
            {
                sb.Append(item + " ");
            }
            return sb.ToString();
        }

        public bool CheckResult()
        {
            //string s = "2 48 56 49 56 48 48 48 56 65 65 66 66 48 48 48 48 48 48 48 48 48 48 48 48 69 49 69 67 13 10 2 48 56 49 56 48 48 48 56 48 48 48 48 48 48 48 48 48 48 48 48 48 48 48 48 52 70 50 50 13 10 ";
            string result = GetReceivedData();
            Regex r = new Regex(@"([2][ ](\d\d\s)*[1][3][\s][1][0][\s])");
            var t = r.Matches(result);

            //foreach (Match match in t)
            //{
            //    Console.WriteLine(match.Value);
            //}

            if (t.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool CheckResult(ref Dictionary<string, EquResult> resultList)
        {
            resultList = new Dictionary<string, EquResult>();
            //string s = "2 48 56 49 56 48 48 48 56 65 65 66 66 48 48 48 48 48 48 48 48 48 48 48 48 69 49 69 67 13 10 2 48 56 49 56 48 48 48 56 48 48 48 48 48 48 48 48 48 48 48 48 48 48 48 48 52 70 50 50 13 10 ";
            string result = GetReceivedData();
            Regex r = new Regex(@"([2][ ](\d\d\s)*[1][3][\s][1][0][\s])");
            var t = r.Matches(result);

            foreach (Match match in t)
            {
                var s1 = match.Value.Replace(" ", "");
                var s2 = s1.Substring(1, s1.IndexOf("1310") - 1 - 4 - 4);

                List<char> chars = new List<char>();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < s2.ToCharArray().Length; i = i + 2)
                {
                    chars.Add((char)int.Parse(s2.Substring(i, 2)));
                    sb.Append((char)int.Parse(s2.Substring(i, 2)));
                }
                string Body = sb.ToString();
                EquResult er = new EquResult();
                er.Command = Body.Substring(0, 4);
                er.dataLength = Body.Substring(4, 4);
                er.dataFlag = Body.Substring(8, 8);
                er.data = Body.Substring(16);

                resultList.Add(er.dataFlag, er);
            }

            if (t.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public int FlashGetVol()
        {

            //Thread.Sleep(10);
            //打开端口
            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.FlashGetVoltage();
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);
            Thread.Sleep(100);
            pcHelper.ClosePort();
            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            int a = MorphologyEquipmentCommandBuilder.Conver16DataStringToInt(result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishGetValue].data);
            return a;
        }

        public bool FlashAddVol(int val)
        {
            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.FlashAddVoltage(val);
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);
            Thread.Sleep(100);
            pcHelper.ClosePort();
            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            if (result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishNoneValue] == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 降低闪光灯电压
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool FlashDecVol(int val)
        {
            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.FlashDecVoltage(val);
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);
            Thread.Sleep(100);
            pcHelper.ClosePort();
            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            if (result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishNoneValue] == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool FlashSetVol(int val)
        {
            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.FlashSetVoltage(val);
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);
            Thread.Sleep(100);
            pcHelper.ClosePort();
            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            if (result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishNoneValue] == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public bool EquReset()
        {

            //Thread.Sleep(10);
            //打开端口
            pcHelper.OpenPort(Port232.PortName, int.Parse(Port232.BaudRate), Port232.DataBits, Port232.StopBites, PortTimeOut);

            byte[] CmdBytes = MECommandBuilder.EquReset();
            ReceivedByteData = new List<byte>();
            pcHelper.SendBytesData(CmdBytes);
            Thread.Sleep(36000);
            pcHelper.ClosePort();
            Dictionary<string, EquResult> result = null;
            CheckResult(ref result);
            if(result[MorphologyEquipmentCommandBuilder.CMDCallBack_FinishNoneValue]!=null)
            { return true; }
            return false;
        }
        /// <summary>
        /// 设备串口返回结果
        /// </summary>
        public class EquResult
        {
            public string Command;
            public string dataLength;
            public string dataFlag;
            public string data;

        }


    }

}
