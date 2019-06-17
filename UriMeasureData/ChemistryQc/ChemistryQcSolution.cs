using System;

namespace Medicside.UriMeasure.Data.ChemistryQc
{
    public class ChemistryQcSolution
    {
        public int ID { get; set; }
        public String QcType { get; set; }

        public string BatchNumber { get; set; }

        public string SolutionName { get; set; }

        public DateTime TermOfValidity { get; set; }


        public string Supplier { get; set; }


        public DateTime RecordDate { get; set; }


        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; }

        public int InstrumentID { get; set; }

        public string InstrumentName { get; set; }
    }
}