using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Interface
{
    public interface IBitmapRead
    {
        int[] Read(byte[] mapdata);

    }
}
