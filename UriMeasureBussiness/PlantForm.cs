using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medicside.UriMeasure.Bussiness
{
    public class PlantForm
    {
       

        private PlantForm() { }

        //public static PlantForm GetInstance(ILog log)
        //{
        //    if (plantForm == null)
        //    {
        //        plantForm = new PlantForm();
        //        logger = log;
        //    }
        //    return plantForm;
        //}
        private static  ILog logger;

        public static  ILog Log
        {
            get { return logger; }
        }

        public static void SetLogger(ILog log)
        {
            logger = log;
        }
    }

}
