using Medicside.UriMeasure.Data.ChemistryQc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicside.UriMeasure.Data.ChemistryQc;

namespace Medicside.UriMeasure.DataAccess.DataHelper
{
    public class ChemistryQcDataHelper
    {

        public static List<ChemistryQcSolution> GetChemistryQcSolutions()
        {

            List<ChemistryQcSolution> list = new List<ChemistryQcSolution>();

            for (int i = 0; i < 15; i++)
            {
                ChemistryQcSolution so = new ChemistryQcSolution();
                so.ID = i + 1000;
                so.QcType = "阳性";
                so.SolutionName = "干化学质控液" + i
                    ;
                so.Supplier = "供应商";
                so.RecordDate = DateTime.Now.AddDays(-2);
                so.TermOfValidity = DateTime.Now.AddDays(+100);
                so.InstrumentName = "干化学仪器CIA";

                list.Add(so);

            }

            return list;


        }

        public static List<ChemistryQcResultItem> GetChemistryQcResultItems()
        {
            List<ChemistryQcResultItem> list = new List<ChemistryQcResultItem>();




            for (int i = 0; i < 20; i++)
            {
                ChemistryQcResultItem item = new ChemistryQcResultItem();


                item.ID = i + 10000;
                item.Name = "干化学质控液A";
                item.QcType = "阳性";
                item.Tester = "Tester";


                list.Add(item);
            }



            return list;


        }

        public static List<ChemistryQcResultSubItem> GetChemistryQcResultSubItems()
        {

            List<ChemistryQcResultSubItem> list = new List<ChemistryQcResultSubItem>();
            var qcs = ChemistryDataHelper.GetChemistryTestChmTypeItems();

            for (int i = 0; i < 10; i++)
            {

                ChemistryQcResultSubItem sub = new ChemistryQcResultSubItem();
                sub.ItemName = qcs[i].ItemName;
                sub.ShortName = qcs[i].ItemID;
                sub.Result = i + 100000000 + "";
                sub.State = "正常";

                list.Add(sub);

            }



            return list;

        }




    }
}
