using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data.Retest
{

    /// <summary>
    /// 尿检培养条件
    /// </summary>
    public class UrineFosterRuleItem
    {


        public UrineFosterRuleItem(int no, string name, string type, int rbc, int bld, int wbc, int leu, int nit, int bact)
        {
            this.Number = no;
            this.Name = name;
            this.TypeName = type;

            this.RBC = rbc;
            this.BLD = bld;
            this.WBC = wbc;
            this.LEU = leu;
            this.NIT = nit;
            this.BACT = bact;
        }

        public int Number { get; set; }

        public String Name { get; set; }

        public String TypeName { get; set; }

        public int RBC { get; set; }

        public int BLD { get; set; }

        public int WBC { get; set; }

        public int LEU { get; set; }

        public int NIT { get; set; }

        public int BACT { get; set; }
    }
}
