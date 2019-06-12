using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriMeasureData.Alarm
{
    class AlarmItem
    {
        public int ID { get; set; }


        public int AlarmNumber { get; set; }

        /// <summary>
        /// 报警时刻
        /// </summary>
        public DateTime AlarmTime { get; set; }
        /// <summary>
        /// 报警信息
        /// </summary>
        public string AlarmMessage { get; set; }
        /// <summary>
        /// 报警类别
        /// </summary>
        public string AlarmType { get; set; }

        public string AlarmLevel { get; set; }
        /// <summary>
        /// 报警设备
        /// </summary>
        public string AlarmEquipment { get; set; }
        /// <summary>
        /// 处理方法
        /// </summary>
        public string CheckMessage { get; set; }
    }
}
