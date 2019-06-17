using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.MorphologyFocus
{
    public class MorphologyRegistRecord
    {

        public int ID { get; set; }

        public bool Enable { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidityOfPeriod { get; set; }
        /// <summary>
        /// 出厂日器
        /// </summary>
        public DateTime DateOfProduction { get; set; }

        /// <summary>
        ///  制造商
        /// </summary>
        public String Manufacturer { get; set; }
        /// <summary>
        /// 登记日期
        /// </summary>
        public DateTime RegistDate { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 条形码
        /// </summary>
        public String BarCode { get; set; }

    }

    public class MorphologyFocusLiquidRegistRecord : MorphologyRegistRecord
    {

    }

    public class MorphologyCalibrationRegistRecord : MorphologyRegistRecord
    {

    }


}
