using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriMeasureData.Calibration
{
    public class CalibrationRecord
    {
        public CalibrationRecord(int id, DateTime time, string actor, string result)
        {
            this.ID = id;
            this.RecordTime = time;
            this.Actor = actor;
            this.Result = result;
        }
        public int ID { get; set; }

        public DateTime RecordTime { get; set; }

        public String Actor { get; set; }


        public String Result { get; set; }

    }
    /// <summary>
    /// 比重计校准记录
    /// </summary>
    public class HydrometerCalibrationRecord : CalibrationRecord
    {
        public HydrometerCalibrationRecord(int id, DateTime time, string actor, string result) : base(id, time, actor, result)
        {

        }
    }
    /// <summary>
    /// 浊度计校准记录
    /// </summary>
    public class TurbidimeterCalibrationRecord : CalibrationRecord
    {
        public TurbidimeterCalibrationRecord(int id, DateTime time, string actor, string result) : base(id, time, actor, result)
        {
        }
    }
    /// <summary>
    /// 电导率校准记录
    /// </summary>
    public class ConductivityCalibrationRecord : CalibrationRecord
    {
        public ConductivityCalibrationRecord(int id, DateTime time, string actor, string result) : base(id, time, actor, result)
        {
        }
    }
}
