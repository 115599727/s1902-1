using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.Chemistry
{
    /// <summary>
    /// 干化学临界值
    /// </summary>
    public class ChemistryThresholdSet
    {
        public string Name { get; set; }

        public List<String> Values;
        public string Unit { get; set; }


    }
}
