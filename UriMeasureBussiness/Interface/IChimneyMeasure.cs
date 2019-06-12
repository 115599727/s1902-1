using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Interface
{
    public interface IChimneyMeasure
    {
        Dictionary<string, string> Measure(object Sample);
        Dictionary<string, string> EmergencyCall(object Sample);
        Dictionary<string, string> LocationMeasure(object Sample);
    }
}
