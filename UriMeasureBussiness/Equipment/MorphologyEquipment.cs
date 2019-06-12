using Medicside.UriMeasure.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
    /// <summary>
    /// 形态学检测仪器
    /// </summary>
   public class MorphologyEquipment : Equipment
    {
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

    }

   
}
