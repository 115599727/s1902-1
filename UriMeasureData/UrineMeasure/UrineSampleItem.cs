using System;

namespace UriMeasure.Data.UrineMeasure
{

    /// <summary>
    /// 样本
    /// </summary>
    public class SampleItem
    {


        public int ID { get; set; }

        public int SampleNo { get; set; }

        /// <summary>
        /// 病患名字
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 试管架号码
        /// </summary>
        public int ShelfNumber { get; set; }

        /// <summary>
        /// 试管号码
        /// </summary>
        public int TubeNumber { get; set; }

        /// <summary>
        /// 病患性别
        /// </summary>
        public string PatientSex { get; set; }

        /// <summary>
        /// 病患年龄
        /// </summary>
        public int PatientAge { get; set; }

        /// <summary>
        /// 病患年龄类型
        /// </summary>
        public string PatientAgeType { get; set; }
        /// <summary>
        /// 病患类型
        /// </summary>
        public string PatientType { get; set; }
        /// <summary>
        /// 收费类型
        /// </summary>
        public string ChargeType { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }
        /// <summary>
        /// 病历号
        /// </summary>
        public int RecordNo { get; set; }
        /// <summary>
        /// 床位号
        /// </summary>
        public int BedNumber { get; set; }
        /// <summary>
        /// 样本类型
        /// </summary>
        public string SampleType { get; set; }
        /// <summary>
        /// 送检时间
        /// </summary>
        public DateTime SendDate { get; set; }


        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// 送检部门
        /// </summary>
        public string SendDepartment { get; set; }
        /// <summary>
        /// 送检医生
        /// </summary>
        public string SendtDoctor { get; set; }
        /// <summary>
        /// 测试医生
        /// </summary>
        public string TestDoctor { get; set; }

        /// <summary>
        /// 稀释倍数
        /// </summary>
        public double DilutionMultiples { get; set; }

        /// <summary>
        /// 复查稀释倍数
        /// </summary>
        public double ReviewDilutionMultiples { get; set; }

        /// <summary>
        /// 测试时间
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime CollectTime { get; set; }
        /// <summary>
        /// 测试类型
        /// </summary>
        public string TestType { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        public string Audit { get; set; }


        public String Note { get; set; }



        /// <summary>
        /// 界面复选选择项
        /// </summary>
        public bool UISelected { get; set; }

        /// <summary>
        /// 条码号
        /// </summary>
        public string BarCode { get; set; }

    }
}