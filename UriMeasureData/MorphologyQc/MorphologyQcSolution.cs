using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.MorphologyQc
{
    /// <summary>
    /// 形态学质控液
    /// </summary>
    public class MorphologyQcSolution
    {
        public int ID { get; set; }
        public String QcType { get; set; }

        public string BatchNumber { get; set; }

        public string SolutionName { get; set; }
        public int RBCAvg { get; set; }

        public int RBCSdValue { get; set; }

        public int WBCAvg { get; set; }

        public int WBCSdValue { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime TermOfValidity { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
        public DateTime RecordDate { get; set; }
        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        public int InstrumentID { get; set; }

        public string InstrumentName { get; set; }


    }

    public class MorphologyQcSolutionType
    {
        public string TypeName { get; set; }
        public int RBCAvg { get; set; }

        public int RBCSdValue { get; set; }

        public int WBCAvg { get; set; }

        public int WBCSdValue { get; set; }

    }
}
