using Medicside.UriMeasure.Data.Calibration;
using System;
using System.Collections.Generic;

namespace Medicside.UriMeasure.DataAccess.DataHelper
{
    /// <summary>
    /// 校准数据
    /// </summary>
    public class CalibrationDataHelper
    {
        /// <summary>
        /// 校准记录
        /// </summary>
        /// <returns></returns>
        public static List<HydrometerCalibrationRecord> GetHydrometerCalibrationRecords()
        {
            List<HydrometerCalibrationRecord> list = new List<HydrometerCalibrationRecord>();

            list.Add(new HydrometerCalibrationRecord(1, DateTime.Now.AddDays(-1), "user1", "通过"));
            list.Add(new HydrometerCalibrationRecord(2, DateTime.Now.AddDays(-1), "user1", "通过"));
            list.Add(new HydrometerCalibrationRecord(3, DateTime.Now.AddDays(-1), "user1", "通过"));

            return list;

        }


    }
}
