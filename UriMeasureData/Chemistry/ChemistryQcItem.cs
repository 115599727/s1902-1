using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriMeasure.Data.Chemistry
{
    /// <summary>
    /// 干化学质控项
    /// </summary>
    public class ChemistryQcItem
    {

        public ChemistryQcItem(Chemistry.ChemistryTestItem testItem)
        {
            this.ChemistryTestItem = testItem;
            this.ItemName = testItem.ItemName;
            this.ShortName = testItem.ItemID;
        }

        public String ItemName { get; set; }

        public bool Enable { get; set; }

        public String ShortName { get; set; }
        /// <summary>
        /// 有阴性靶值
        /// </summary>
        public bool HadNegativeTarget { get; set; }

        public string NegativeTargetUpper { get; set; }

        public string NegativeTargetLower { get; set; }


        /// <summary>
        /// 有阳性靶值
        /// </summary>
        public bool HadPositiveTarget { get; set; }

        public string PositiveTargetUpper { get; set; }

        public string PositiveTargetLower { get; set; }

        public Chemistry.ChemistryTestItem ChemistryTestItem { get; set; }

    }
}
