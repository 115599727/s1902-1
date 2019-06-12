using Medicside.UriMeasure.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Plant
{
    /// <summary>
    /// 形态学检测平台TypeB
    /// </summary>
    public class PlantB:PlantForm
    {
        /// <summary>
        /// 图像识别类
        /// </summary>
        public IBitmapRead BitmapReader{ get; set; }

        /// <summary>
        /// 形态学设备
        /// </summary>
        public Equipment.MorphologyEquipment MorphologyEQU { get; set; }









    }
}
