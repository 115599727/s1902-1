using Medicside.UriMeasure.Data;
using Medicside.UriMeasure.Data.DataHelper;
using Medicside.UriMeasure.Data.Morphology;
using Medicside.UriMeasure.Data.UrineMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medicside.UriMeasure.DataAccess.DataHelper
{
  public  class UrineTestDataHelper
    {
        public static List<UrineTestResult> GetUrineTestResults()
        {

            List<UrineTestResult> list = new List<UrineTestResult>();

            for (int i = 0; i < 30; i++)
            {
                UrineTestResult result = new UrineTestResult();

                result.ID = i + 10000;
                result.SampleNo = 200 + i;
                result.PatientName = "病患" + i;
                result.ShelfNumber = 4;
                result.TubeNumber = i % 7;
                result.TestDate = DateTime.Now;
                result.IsPrint = false;
                result.TestType = "干化学+形态学";
                result.DilutionMultiples = 8;
                result.ReviewDilutionMultiples = 16;
                list.Add(result);
            }

            return list;

        }

        public static List<SampleItem> GetUrineSampleItems()
        {

            List<SampleItem> list = new List<SampleItem>();

            for (int i = 0; i < 30; i++)
            {
                SampleItem result = new SampleItem();

                result.ID = i + 10000;
                result.SampleNo = 200 + i;
                result.PatientName = "病患" + i;
                result.ShelfNumber = 4;
                result.TubeNumber = i % 7;
                result.TestDate = DateTime.Now;
                result.RecordNo = 100;
                result.SendDate = DateTime.Now;
                result.SendDepartment = "内科";
                result.PatientSex = "男";

                //result.IsPrint = false;
                result.TestType = "干化学+形态学";
                result.DilutionMultiples = 8;
                result.ReviewDilutionMultiples = 16;
                list.Add(result);
            }

            return list;


        }

        public static List<UrineTestResultItem> GetUrineTestResultItems()
        {

            List<UrineTestResultItem> list = new List<UrineTestResultItem>();
            var morList = MorphologyDataHelper.GetMorphologyTestItems();

            foreach (var item in morList)
            {
                UrineTestResultItem it = new UrineTestResultItem();
                it.ResultName = item.ItemName;
                if (item.TestType != null)
                {
                    it.ResultType = item.TestType.ToString();
                }
                else
                {
                    it.ResultType = "";
                }

                if (item.SubTestItems != null)
                {
                    AddSubItem(list, item);

                }
                it.ItemUnit = item.ItemUnit.ToString();
                it.Reference = item.Reference;
                it.Result = "3.49";
                it.TestType = "形态学检测类";
                it.Abnormal = true;
                list.Add(it);

            }

            //干化学
            var chmList = ChemistryDataHelper.GetChemistryTestChmTypeItems( );


            foreach (var item in chmList)
            {
                UrineTestResultItem it = new UrineTestResultItem();
                it.ResultName = item.ItemName;
                it.ResultType = item.TestType.ToString();
                it.Result = ".39";
                it.Reference = item.Reference;
                it.ItemUnit = item.ItemUnit;
                it.TestType = "干化学检测类";
                list.Add(it);
            }


            return list;

        }

        private static void AddSubItem(List<UrineTestResultItem> morList, MorphologyTestItem item)
        {
            foreach (var it in item.SubTestItems)
            {
                UrineTestResultItem newit = new UrineTestResultItem();
                newit.ResultName = it.ItemName;
                if (it.TestType != null)
                {
                    newit.ResultType = it.TestType.ToString();
                }
                else
                {
                    newit.ResultType = "";
                }
                newit.ItemUnit = it.ItemUnit.ToString();
                newit.Reference = it.Reference;
                newit.Result = "3.49";
                newit.TestType = "形态学检测类";
                newit.Abnormal = true;
                morList.Add(newit);
            }
        }
        /// <summary>
        /// 获取形态学结果
        /// </summary>
        /// <returns></returns>
        public static List<UrineTestResultItem> GetUrineTestMorphologyResultItems()
        {

            List<UrineTestResultItem> list = new List<UrineTestResultItem>();
            var morList = MorphologyDataHelper.GetMorphologyTestItems();

            foreach (var item in morList)
            {
                UrineTestResultItem it = new UrineTestResultItem();
                it.ResultName = item.ItemName;
                if (item.TestType != null)
                {
                    it.ResultType = item.TestType.ToString();
                }
                else
                {
                    it.ResultType = "";
                }
                it.ItemUnit = item.ItemUnit.ToString();
                it.Reference = item.Reference;
                it.Result = "3.49";
                it.TestType = "形态学检测类";
                if (item.SubTestItems != null)
                {
                    AddSubItem(list, item);

                }
                list.Add(it);

            }




            return list;

        }


        public static List<MorphologyPicCatalogItem> GetUrineMorphologyPicCatalog()
        {
            List<MorphologyPicCatalogItem> list = new List<MorphologyPicCatalogItem>();

            var morList = MorphologyDataHelper.GetMorphologyTestItems();
            foreach (var item in morList)
            {
                MorphologyPicCatalogItem it = new MorphologyPicCatalogItem();
                it.CatalogName = item.ItemName;
                it.CatalogShortName = item.ShortName;

                list.Add(it);
            }

            return list;


        }
        /// <summary>
        /// 尿检干化学结果项目
        /// </summary>
        /// <returns></returns>
        public static List<UrineTestResultItem> GetUrineTestChemistryResultItems()
        {

            List<UrineTestResultItem> list = new List<UrineTestResultItem>();


            //干化学
            var chmList = ChemistryDataHelper.GetChemistryTestChmTypeItems();


            foreach (var item in chmList)

            {
                UrineTestResultItem it = new UrineTestResultItem();
                it.ResultName = item.ItemName;
                it.ResultType = item.TestType.ToString();
                it.Reference = item.Reference;
                it.ItemUnit = item.ItemUnit;
                it.Result = ".39";
                it.TestType = "干化学检测类";
                list.Add(it);
            }


            return list;

        }


        /// <summary>
        /// 获取患者类型
        /// </summary>
        /// <returns></returns>
        public static List<DictionaryItem> GetPatientTypes()
        {
            List<DictionaryItem> list = new List<DictionaryItem>();

            list.Add(new DictionaryItem(1, "门诊", "m"));
            list.Add(new DictionaryItem(2, "急诊", "j"));
            list.Add(new DictionaryItem(3, "住院", "z"));
            return list;

        }
        /// <summary>
        /// 获取年龄类型
        /// </summary>
        /// <returns></returns>
        public static List<DictionaryItem> GetPatientAgeTypes()
        {
            List<DictionaryItem> list = new List<DictionaryItem>();

            list.Add(new DictionaryItem(1, "岁", "s"));
            list.Add(new DictionaryItem(2, "月", "y"));
            list.Add(new DictionaryItem(3, "天", "t"));
            list.Add(new DictionaryItem(3, "小时", "t"));
            return list;

        }
        /// <summary>
        /// 获取收费类型
        /// </summary>
        /// <returns></returns>
        public static List<DictionaryItem> GetChargeTypes()
        {
            List<DictionaryItem> list = new List<DictionaryItem>();

            list.Add(new DictionaryItem(1, "医保", "y"));
            list.Add(new DictionaryItem(2, "农合", "n"));
            list.Add(new DictionaryItem(3, "自费", "z"));

            return list;

        }
        /// <summary>
        /// 获取民族类型
        /// </summary>
        /// <returns></returns>
        public static List<DictionaryItem> GetNations()
        {
            List<DictionaryItem> list = new List<DictionaryItem>();

            list.Add(new DictionaryItem(1, "汉族", "h"));
            list.Add(new DictionaryItem(2, "朝鲜族", "c"));
            list.Add(new DictionaryItem(3, "回族", "h"));
            list.Add(new DictionaryItem(3, "满族", "m"));
            return list;

        }


        /// <summary>
        /// 获取测试类型
        /// </summary>
        /// <returns></returns>
        public static List<DictionaryItem> GetTestTypes()
        {
            List<DictionaryItem> list = new List<DictionaryItem>();

            list.Add(new DictionaryItem(1, "干化学+形态学", "2"));
            list.Add(new DictionaryItem(2, "干化学", "g"));
            list.Add(new DictionaryItem(3, "形态学", "x"));

            return list;

        }
    }
}
