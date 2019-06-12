using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medicside.UriMeasure.Bussiness.Plant
{
    public class PlantForm
    {
        
        static PlantForm plantForm;

        protected PlantForm() { }

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
                return plantForm;
            }
            return plantForm;
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

        private  void SetLogger(ILog log)
        {
            logger = log;
        }





    }
    /// <summary>
    /// 平台类型
    /// </summary>
    public enum PlantMeasureType
    {

        TypeAChemistry,TypeBMorphplogy,TypeABChemistryAndMorphplogy, TypeCchemistryAndMorphplogyAndAutoDisk
    }

}
