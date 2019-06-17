using Medicside.UriMeasure.Data.Retest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicside.UriMeasure.Data.Retest;

namespace Medicside.UriMeasure.DataAccess.DataHelper
{
   public class RetestConditionDataHelper
    {
        public static List<MicroscopyCheckItem> GetMicrosCopyCheckItems()
        {

            List<MicroscopyCheckItem> list = new List<MicroscopyCheckItem>();

            list.Add(new MicroscopyCheckItem(1, "1", "", 1, 1, 1, -1, 1, 1));
            list.Add(new MicroscopyCheckItem(2, "2", "", 1, 1, 1, -1, 1, 1));
            list.Add(new MicroscopyCheckItem(3, "3", "", 1, 1, 1, -1, 1, 1));
            list.Add(new MicroscopyCheckItem(4, "4", "", 1, 1, 1, -1, 1, 1));
            list.Add(new MicroscopyCheckItem(5, "5", "", 1, 1, 1, -1, 1, 1));
            list.Add(new MicroscopyCheckItem(6, "6", "", 1, 1, 1, -1, 1, 1));
            return list;
        }


        public static List<UrineFosterRuleItem> GetUrineRuleItems()
        {

            List<UrineFosterRuleItem> list = new List<UrineFosterRuleItem>();

            list.Add(new UrineFosterRuleItem(1, "1", "", 1, 1, 1, -1, 1, 1));
            list.Add(new UrineFosterRuleItem(2, "2", "", 1, 1, 1, -1, 1, 1));
            list.Add(new UrineFosterRuleItem(3, "3", "", 1, 1, 1, -1, 1, 1));
            list.Add(new UrineFosterRuleItem(4, "4", "", 1, 1, 1, -1, 1, 1));
            list.Add(new UrineFosterRuleItem(5, "5", "", 1, 1, 1, -1, 1, 1));
            list.Add(new UrineFosterRuleItem(6, "6", "", 1, 1, 1, -1, 1, 1));

            return list;


        }

    }

}
