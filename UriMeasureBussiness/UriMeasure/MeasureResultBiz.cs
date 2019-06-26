﻿using Medicside.UriMeasure.Data.UrineMeasure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.UriMeasure
{
   public class MeasureResultBiz: BuissinessBase
    {

        public readonly String GridSamplelistHead = "UiUriMeasure.MeasureResult.SamplelistHead";
        public readonly String GridSamplelistMap = "UiUriMeasure.MeasureResult.SamplelistMap";
        public readonly String GridResultlistHead = "UiUriMeasure.MeasureResult.ResultlistHead";
        public readonly String GridResultlistMap = "UiUriMeasure.MeasureResult.ResultlistMap";


        List<UrineTestResult> listSamples;
        public Dictionary<string, string> SampleGrideHeadList;
        public Dictionary<string, string> ResultGrideHeadList;
        public MeasureResultBiz()
        {
            Log.Debug("");
            DataAccess.DataHelper.UrineTestDataHelper.GetUrineSampleItems();

            SampleGrideHeadList = GetGridHeadItems(GridSamplelistHead, GridSamplelistMap);

            ResultGrideHeadList = GetGridHeadItems(GridResultlistHead, GridResultlistMap);
        }
        public string[] GridSampleMapNames
        {
            get
            {
                return GetGridConfigString(GridSamplelistMap);

            }
        }
        public string[] GridSampleColNames
        {
            get
            {
                return GetGridConfigString(GridSamplelistHead);

            }
        }
        public string[] GridResultMapNames
        {
            get
            {
                return GetGridConfigString(GridResultlistHead);

            }
        }
        public string[] GridResultColNames
        {
            get
            {
                return GetGridConfigString(GridResultlistHead);

            }
        }
    }
}
