using Medicside.UriMeasure.Data.ChemistryQc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicside.UriMeasure.Data.ChemistryQc;

namespace Medicside.UriMeasure.DataAccess.DataHelper
{
  public  class StandardBarQcDataHelper
    {
        public static List<StandardBarQcTestResultItem> GetStandardBarQcTestResultItems()
        {
            List<StandardBarQcTestResultItem> list = new List<StandardBarQcTestResultItem>();

            for (int i = 0; i < 20; i++)
            {

                StandardBarQcTestResultItem item = new StandardBarQcTestResultItem();
                item.ItemID = i + 100000;
                item.Tester = "user";
                item.TestTime = DateTime.Now.AddDays(-i);
                item.Result = "成功";

                list.Add(item);

            }



            return list;

        }
    }
}
