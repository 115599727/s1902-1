using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Camera
{
    public class ShotImage
    {
        public ShotImage(int newWidth, int newHeight, Byte[] newBuffer, bool color, long timeStamp)
        {
            Width = newWidth;
            Height = newHeight;
            Buffer = newBuffer;
            Color = color;
            TimeStamp = timeStamp;
            CreateTime = DateTime.Now;
        }
        public DateTime CreateTime;
        public readonly long TimeStamp;
        public readonly int Width; /* The width of the image. */
        public readonly int Height; /* The height of the image. */
        public readonly Byte[] Buffer; /* The raw image data. */
        public readonly bool Color; /* If false the buffer contains a Mono8 image. Otherwise, RGBA8packed is provided. */
    }
}
