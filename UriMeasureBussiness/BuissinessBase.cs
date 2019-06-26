using Medicside.UriMeasure.Bussiness.Plant;
using System;
using System.Collections.Generic;
using System.Windows;


namespace Medicside.UriMeasure.Bussiness
{
    public class BuissinessBase
    {
        public log4net.ILog Log;
        public ResourceDictionary Resourse;
        public BuissinessBase()
        {
            Log = PlantForm.Log;
            Resourse = PlantForm.Resourse;
        }

        /// <summary>
        /// 加载列标题
        /// </summary>
        /// <param name="TextKye">标题文本的Key</param>
        /// <param name="MapKey">映射字典的Key</param>
        /// <returns></returns>
        public  Dictionary<string,string> GetGridHeadItems(string TextKey,string MapKey)
        {

            string cols = Resourse[TextKey].ToString();
            string maps = Resourse[MapKey].ToString();

            //加载列明
            //string cols = "选择|架号|管号|样本编号|条码号|病患名字|性别|年|齢|民族|病历号|病患类型|收费类型|样本类型|稀释|采样时间|送检时间|登记时间|送检科室|送检医生|检测时间|备注";
            //string maps = "UISelected|ShelfNumber|TubeNumber|SampleNo|BarCode|PatientName|PatientSex|PatientAge|PatientAgeType|Nation|RecordNo|PatientType|ChargeType|SampleType|DilutionMultiples|CollectTime|SendDate|RegisterDate|SendDepartment|SendtDoctor|SendDate|Note";
            string[] colNames = cols.Split(new char[] {'|'});
            string[] mapNames = maps.Split(new char[] {'|'});
            Dictionary<string, string> GrideHeadList;
            if (colNames.Length == mapNames.Length)
            {
                GrideHeadList = new Dictionary<string, string>(mapNames.Length);
                for (int i = 0; i < mapNames.Length; i++)
                {
                    GrideHeadList.Add(mapNames[i], colNames[i]);
                }
              
            }
            else
            {
                string err = "Grid Head items Error" + cols.Length + "|" + maps.Length;

                Log.Error(err);
                throw new FormatException(err);

            }
             return GrideHeadList;
        }

        public string[] GetGridConfigString(string keyString)
        {

            string maps = Resourse[keyString].ToString();
            return maps.Split(new char[] { '|' });
        }
    }
}