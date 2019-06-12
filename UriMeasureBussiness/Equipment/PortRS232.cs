using System;
using System.IO.Ports;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
    /// <summary>
    /// 串口设备
    /// </summary>
    public class PortRS232
    {
       
        /// <summary>
        /// 串口号
        /// </summary>
        public String PortName { get; set; }

        /// <summary>
        /// 波特率选择  BaudRate   115200默认值，
        /// </summary>
        public String BaudRate { get; set; }

        /// <summary>
        /// 奇偶校验、Parity
        /// </summary>
        public Parity Parity { get; set; }

        //停止位、StopBits
        /// <summary>
        /// 停止位的数目
        /// </summary>
        public SerialPort StopBites { get; set; }

        /// <summary>
        /// 数据位，DataBits
        /// </summary>
        public int DataBits { get; set; }

    }
}