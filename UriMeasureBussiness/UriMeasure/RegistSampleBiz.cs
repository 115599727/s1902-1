using Medicside.UriMeasure.Bussiness.Plant;

using Medicside.UriMeasure.Data.Morphology;
using Medicside.UriMeasure.Data.UrineMeasure;
using Medicside.UriMeasure.DataAccess;
using Medicside.UriMeasure.DataAccess.DataHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.UriMeasure
{
    public class RegistSampleBiz : BuissinessBase
    {

        /// <summary>
        /// 样本编号提示
        /// </summary>
        private int sampleNo;
        public int SampleNo
        {
            get { return sampleNo; }

            set
            {
                if (value > 1 && value < 10000)
                {
                    sampleNo = value;
                }
            }
        }

        public List<SampleItem> SampleList;

        public readonly String GridSamplelistHead = "UiUriMeasure.RegisterSample.SamplelistHead";
        public readonly String GridSamplelistMap = "UiUriMeasure.RegisterSample.SamplelistMap";
        
        public Dictionary<string, string> GrideHeadList;

        public string[] GridMapNames
        {
            get
            {
                return GetGridConfigString(GridSamplelistMap);
               
            }
        }
        public string[] GridColNames
        {
            get
            {
                return GetGridConfigString(GridSamplelistHead);
                
            }
        }




        public RegistSampleBiz()
        {
            Log.Debug("创建 RegistSampleBiz");

            //SampleList = new List<SampleItem>();
            SampleList = DataAccess.DataHelper.UrineTestDataHelper.GetUrineSampleItems();

            //加载列明
            GrideHeadList = GetGridHeadItems(GridSamplelistHead, GridSamplelistMap);


        }


        /// <summary>
        /// 送检部门
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetSendDepartments()
        {
           return PlantForm.Current.GetDictionaryData(DictionaryDataType.UrineMeasureSendDepartment);
        }

        public IEnumerable GetSendDoctors()
        {
            return PlantForm.Current.GetDictionaryData(DictionaryDataType.UrineMeasureSendDoctor);
        }

        /// <summary>
        /// 获取稀释倍数配置项
        /// </summary>
        /// <returns></returns>
        public  List<DilutionItem> GetDilutionItems()
        {

            return MorphologyDataHelper.GetDilutionItems();
        }

        /// <summary>
        /// 执行检测
        /// </summary>
        /// <param name="item"></param>
        public void Measure(List<SampleItem> item)
        {

            //PlantForm.Current.Measure(item);
           // throw new NotImplementedException();
        }
    }
}
