using log4net;
using Medicside.UriMeasure.Data;
using Medicside.UriMeasure.Data.UrineMeasure;
using Medicside.UriMeasure.DataAccess.DataHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Medicside.UriMeasure.Bussiness.Plant
{
    public  class PlantForm
    {
        static PlantForm plantForm;
        
        protected PlantForm() { }

        public static PlantForm Current
        {
            get
            {
                return plantForm;
            }
        }

        public static PlantForm GetInstance(ILog log,PlantMeasureType type)
        {
            
            if (plantForm == null)
            {
                //创建 设备类型
                switch (type)
                {
                    case PlantMeasureType.TypeAChemistry:
                        plantForm = new PlantA();
                        break;
                    case PlantMeasureType.TypeBMorphplogy:
                        plantForm = new PlantB();
                        break;
                    case PlantMeasureType.TypeABChemistryAndMorphplogy:
                        plantForm = new PlantAB();
                        break;
                    case PlantMeasureType.TypeCchemistryAndMorphplogyAndAutoDisk:
                        plantForm = new PlantC();
                        break;
                    default:
                        return null;
                }
                plantForm.PlantType = type;
                //plantForm = new PlantForm();
                plantForm.SetLogger(log);
                plantForm.DateTimeFormatString = "yyyy/MM/dd";


                return plantForm;
            }
            return plantForm;
        }

        public static  void SetResourse(ResourceDictionary resources)
        {
            PlantForm.Resourse = resources;
        }

        private static  ILog logger;
        private PlantMeasureType plantType;
        public PlantMeasureType PlantType
        {
            protected set { this.plantType = value; }
            get { return plantType; }
        }

        public static  ILog Log
        {
            get { return logger; }
        }

        public static ResourceDictionary Resourse { get; internal set; }

        private  void SetLogger(ILog log)
        {
            logger = log;
        }

        public List<DictionaryItem> GetDictionaryData(DictionaryDataType type)
        {


            List <DictionaryItem> list= new List<DictionaryItem>();

            //获取年龄类型
            if (type==DictionaryDataType.UrineMeasurePatientAgeType)
            {
                list = UrineTestDataHelper.GetPatientAgeTypes();
            }
            //获取患者类型
            if (type == DictionaryDataType.UrineMeasurePatientType)
            {
                list = UrineTestDataHelper.GetPatientTypes();
            }
            //民族
            if (type == DictionaryDataType.UrineMeasurePatientNations)
            {
                list = UrineTestDataHelper.GetNations();
            }
            //收费类型
            if (type == DictionaryDataType.UrineMeasureChargeTypes)
            {
                list = UrineTestDataHelper.GetChargeTypes();
            }
            //送检科室
            if (type == DictionaryDataType.UrineMeasureSendDepartment)
            {
                list = UrineTestDataHelper.GetSendDepartments();
            }
            //送检医生
            if (type == DictionaryDataType.UrineMeasureSendDoctor)
            {
                list = UrineTestDataHelper.GetSendDoctors();
            }
            return list;

        }

        //检测操作
        internal virtual void Measure(SampleItem item)
        {
            
        }


        public string DateTimeFormatString { get; set; }

    }
    /// <summary>
    /// 平台类型
    /// </summary>
    public enum PlantMeasureType
    {
        TypeAChemistry=100,TypeBMorphplogy=200,TypeABChemistryAndMorphplogy=300, TypeCchemistryAndMorphplogyAndAutoDisk=500
    }
    public enum DictionaryDataType
    {
        UrineMeasurePatientAgeType, UrineMeasurePatientType, UrineMeasurePatientNations, UrineMeasureChargeTypes
            , UrineMeasureSendDepartment, UrineMeasureSendDoctor

    }

    

}
