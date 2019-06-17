using Medicside.UriMeasure.Data.MorphologyQc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicside.UriMeasure.Data.MorphologyQc;

namespace Medicside.UriMeasure.DataAccess.DataHelper
{
  public  class MorphologyQcDataHelper
    {

        public static List<MorphologyQcSolution> GetMorphologyQcSolutions()
        {

            List<MorphologyQcSolution> list = new List<MorphologyQcSolution>();
            for (int i = 0; i < 20; i++)
            {
                MorphologyQcSolution so = new MorphologyQcSolution();

                so.ID = i + 100;
                if (i % 2 == 0)
                {
                    so.QcType = "单质控-阴性质控水平";
                }
                else
                {
                    so.QcType = "单质控-阳性质控水平";
                }
                so.BatchNumber = "12344456";
                so.SolutionName = "形态学质控液";
                so.TermOfValidity = DateTime.Now.AddDays(30);
                so.RBCAvg = 0;
                so.RBCSdValue = 100;
                so.WBCAvg = 10;
                so.WBCSdValue = 80;
                so.RecordDate = DateTime.Now.AddDays(-5);



                list.Add(so);
            }




            return list;
        }


        public static List<MorphologyQcResultItem> GetMorphologyQcResultItems()
        {

            List<MorphologyQcResultItem> list = new List<MorphologyQcResultItem>();

            for (int i = 0; i < 20; i++)
            {
                MorphologyQcResultItem so = new MorphologyQcResultItem();

                so.ID = i + 100;

                so.BatchNumber = "12344456";
                so.TestTime = DateTime.Now;
                //so.SolutionName = "形态学质控液";
                //so.TermOfValidity = DateTime.Now.AddDays(30);
                so.RBCAvg = 0;
                so.RBCSdValue = 100;
                so.WBCAvg = 10;
                so.WBCSdValue = 80;
                so.IsPass = true;
                so.InstrumentName = "形态学仪器 MA1";
                //so.RecordDate = DateTime.Now.AddDays(-5);
                list.Add(so);
            }




            return list;




        }

        /// <summary>
        /// 
        /// 形态学指控类型
        /// </summary>
        /// <returns></returns>
        public static List<string> GettMorphologyQcSolutionTypes()
        {
            List<string> list = new List<string>();
            list.Add("单质控-阴性质控液");
            list.Add("单质控-阳性质控液水平1");
            list.Add("单质控-阳性质控液水平2");
            list.Add("单质控-阳性质控液水平3");
            list.Add("复合质控-质控物水平1");
            list.Add("复合质控-质控物水平2");
            list.Add("复合质控-质控物水平3");
            return list;


        }
    }
}
