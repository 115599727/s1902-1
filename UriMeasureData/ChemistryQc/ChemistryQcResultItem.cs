using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.ChemistryQc
{
    public class ChemistryQcResultItem
    {


        public int ID { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNumber { get; set; }
        /// <summary>
        /// 样本编号
        /// </summary>
        public string SampleNumber { get; set; }

        public DateTime TestTime { get; set; }

        public string Name { get; set; }
        public String QcType { get; set; }
        public ChemistryQcSolution QcSolution { get; set; }

        //public System.Drawing.Image PassImage
        //{
        //    get; set;
        //}

        public int InstrumentID { get; set; }

        public string InstrumentName { get; set; }

        public bool IsPass { get; set; }

        public String Tester { get; set; }

    }

    public class ChemistryQcResultSubItem
    {
        public String ItemName { get; set; }
        public String ShortName { get; set; }

        public string Result { get; set; }

        public string State { get; set; }

    }
}
