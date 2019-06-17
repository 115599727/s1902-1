using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.MorphologyFocus
{

    /// <summary>
    /// 形态学仪器聚焦记录
    /// </summary>
    public class MorphologyRecord
    {
        public int ID { get; set; }

        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }

        public string Result { get; set; }
        /// <summary>
        /// 批号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidityOfPeriod { get; set; }
    }


    public class MorphologyFocusRecord : MorphologyRecord
    {

    }
}
