using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
    
    class MorphologyEquipmentCommandBuilder
    {
       public static String CMDCallBack_FinishGetValue = "AADD0000";
       public static String CMDCallBack_FinishNoneValue = "00000000";
       public static String CMDCallBack_RecivedCMD = "AABB0000";
       public static String CMDCallBack_FinishAlart = "AACC0000";


        // 开始码 0x02
        static String CRCHead = "02";
        static String CameraShotCMD = "0818";
        static String FlashGetVolCMD = "0811";
        static String FlashSetVolCMD = "0810";
        static String FlashAddVolCMD = "0821";
        static String FlashDecVolCMD = "0822";//减少电压
        public byte[] GetShotCommand()
        {

            StringBuilder sbCmdbody = new StringBuilder();
            //命令码 0x0202
            var command = CameraShotCMD;
            sbCmdbody.Append(command);
            //数据包
            int DataLength = 4;
            sbCmdbody.Append(Conver16DataString(DataLength, 2));
            int data0 = 200;
            sbCmdbody.Append(Conver16DataString(data0, 2));
            int data1 = 2000;
            sbCmdbody.Append(Conver16DataString(data1, 2));

            String strbody = sbCmdbody.ToString().ToUpper();

            return BuildCommand(strbody).ToArray();
        }
        public byte[] GetShotCommand(int shotHz, int shotCount)
        {

            StringBuilder sbCmdbody = new StringBuilder();
            //命令码 0x0202
            var command = CameraShotCMD;
            sbCmdbody.Append(command);
            //数据包
            int DataLength = 4;
            sbCmdbody.Append(Conver16DataString(DataLength, 2));
            int data0 = shotHz;
            sbCmdbody.Append(Conver16DataString(data0, 2));
            int data1 = shotCount;
            sbCmdbody.Append(Conver16DataString(data1, 2));

            String strbody = sbCmdbody.ToString().ToUpper();

            return BuildCommand(strbody).ToArray();
        }
        private static byte[] GetCRCData(string head, StringBuilder sbCmdbody)
        {
            //CRC校验
            sbCmdbody.Insert(0, head);
            string cmmddataStr = sbCmdbody.ToString().ToUpper();

            var crcint = Crc16.CRC16_MODBUS(PortControlHelper.strToToHexByte(cmmddataStr));
            var crcdata = Encoding.ASCII.GetBytes(Convert.ToString(crcint, 16).ToUpper());
            return crcdata;
        }
        List<byte> BuildCommand(String bodyStr)
        {
            List<byte> list = new List<byte>();
            var t = Encoding.ASCII.GetBytes(bodyStr.ToCharArray());
            

            list.Add(2);
            list.AddRange(t);

            byte[] crcdata = GetCRCData(CRCHead, new StringBuilder(bodyStr));
            list.AddRange(crcdata);

            //数据包停止位 0x0d 0x0a
            list.Add(13);
            list.Add(10);

            return list;
        }
        /// <summary>
        /// 整数转换成len位的16进制字符串，长度2*len。
        /// </summary>
        /// <param name="data"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        static string Conver16DataString(int data, int len)
        {
            string s = Convert.ToString(data, 16).ToUpper();
            int slen = s.Length;
            if (len * 2 < slen)
            {
                throw new Exception("位数转换错误");
            }

            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < len * 2 - slen; i++)
            {
                sb.Insert(0, "0");
            }
            return sb.ToString();

        }
       public static int Conver16DataStringToInt(string input)
        {
            string instr;
            //string instr = input.Replace(("0", "");
            int i = 0;
            for (; i < input.Length; i++)
            {
                if(input[i]=='0')
                {
                    continue;
                }
                break;
            }
            if (i == input.Length - 1)
            {
                instr = "0";
            }
            else
            {
                instr = input.Substring(i);
            }
            int k=Convert.ToInt32(instr, 16);
            return k;
        }
        /// <summary>
        /// 读闪光灯电压
        /// </summary>
        /// <returns>返回电压值</returns>
        public byte[] FlashGetVoltage()
        {

            StringBuilder sbCmdbody = new StringBuilder();
            //命令码 0x0202
            var command = FlashGetVolCMD;
            sbCmdbody.Append(command);
            //数据包
            int DataLength = 0;
            sbCmdbody.Append(Conver16DataString(DataLength, 2));
            ////int data0 = 200;
            ////sbCmdbody.Append(Conver16DataString(data0, 2));
            ////int data1 = 2000;
            ////sbCmdbody.Append(Conver16DataString(data1, 2));

            String strbody = sbCmdbody.ToString().ToUpper();

            return BuildCommand(strbody).ToArray();
        }

        /// <summary>
        /// 增加闪光灯电压
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public byte[] FlashAddVoltage(int val=42)
        {

            StringBuilder sbCmdbody = new StringBuilder();
            //命令码 0x0202
            var command = FlashAddVolCMD;
            sbCmdbody.Append(command);
            //数据包
            int DataLength = 2;
            sbCmdbody.Append(Conver16DataString(DataLength, 2));
            int data0 = val;
            sbCmdbody.Append(Conver16DataString(data0, 2));
            ////int data1 = 2000;
            ////sbCmdbody.Append(Conver16DataString(data1, 2));

            String strbody = sbCmdbody.ToString().ToUpper();

            return BuildCommand(strbody).ToArray();
        }
        /// <summary>
        /// 减少闪光灯电压
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public byte[] FlashDecVoltage(int val = 42)
        {

            StringBuilder sbCmdbody = new StringBuilder();
            //命令码 0x0202
            var command = FlashDecVolCMD;
            sbCmdbody.Append(command);
            //数据包
            int DataLength = 2;
            sbCmdbody.Append(Conver16DataString(DataLength, 2));
            int data0 = val;
            sbCmdbody.Append(Conver16DataString(data0, 2));
            ////int data1 = 2000;
            ////sbCmdbody.Append(Conver16DataString(data1, 2));

            String strbody = sbCmdbody.ToString().ToUpper();

            return BuildCommand(strbody).ToArray();
        }

        public byte[] FlashSetVoltage(int val = 2200)
        {

            StringBuilder sbCmdbody = new StringBuilder();
            //命令码 0x0202
            var command = FlashSetVolCMD;
            sbCmdbody.Append(command);
            //数据包
            int DataLength = 2;
            sbCmdbody.Append(Conver16DataString(DataLength, 2));
            int data0 = val;
            sbCmdbody.Append(Conver16DataString(data0, 2));
            ////int data1 = 2000;
            ////sbCmdbody.Append(Conver16DataString(data1, 2));

            String strbody = sbCmdbody.ToString().ToUpper();

            return BuildCommand(strbody).ToArray();
        }
    }
}
