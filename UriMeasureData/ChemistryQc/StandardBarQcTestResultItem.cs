using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.ChemistryQc
{
    public class StandardBarQcTestResultItem
    {

        public int ItemID { get; set; }
        public DateTime TestTime { get; set; }

        public String Tester { get; set; }

        public string Result { get; set; }

    }
}
