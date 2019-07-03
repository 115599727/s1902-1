using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Camera
{
    interface IGrabImage
    {
        int SetNUM_GRABS { set; }

        List<ShotImage> ResultImageList { get; }

        void GrabImage();
        void SaveImage(string path = "e:\\cimage\\");

        bool IsCameraConnected();
    }
}
