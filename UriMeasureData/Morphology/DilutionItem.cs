using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.Morphology
{
    /// <summary>
    /// 稀释项目
    /// </summary>
    public class DilutionItem
    {

        public DilutionItem(string mnmeonic, decimal value)
        {
            this.Mnemonic = mnmeonic;
            this.Value = value;
        }
        /// <summary>
        /// 助记符
        /// </summary>
        public string Mnemonic { get; set; }

        public decimal Value { get; set; }

    }
}
