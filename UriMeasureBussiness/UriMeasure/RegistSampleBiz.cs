using Medicside.UriMeasure.Data.UrineMeasure;
using Medicside.UriMeasure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.UriMeasure
{
    public class RegistSampleBiz : BuissinessBase
    {
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





    }
}
