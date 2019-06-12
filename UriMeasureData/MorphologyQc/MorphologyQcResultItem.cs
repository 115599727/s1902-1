using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriMeasure.Data.MorphologyQc
{
    public class MorphologyQcResultItem
    {

        public int ID { get; set; }
        public String QcType { get; set; }

        public DateTime TestTime { get; set; }

        public string BatchNumber { get; set; }

        public string Name { get; set; }

        public int RBCNumber { get; set; }

        public int WBCNumber { get; set; }
        /// <summary>
        /// 结晶
        /// </summary>
        public int CrystalNumber { get; set; }
        /// <summary>
        /// 管型
        /// </summary>
        public int TubeType { get; set; }

        public int RBCAvg { get; set; }

        public int RBCSdValue { get; set; }

        public int WBCAvg { get; set; }

        public int WBCSdValue { get; set; }

        /// <summary>
        /// 系数
        /// </summary>
        public double Ratio { get; set; }


        public bool IsPass { get; set; }

        public MorphologyQcSolution QcSolution { get; set; }

        //public System.Drawing.Image PassImage
        //{
        //    get; set;
        //}

        public int InstrumentID { get; set; }

        public string InstrumentName { get; set; }
    }
}
