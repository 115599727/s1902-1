using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Interface
{
    public interface IMorphplogyMeasure
    {
        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        Dictionary<string, string> Measure(object sample);



    }
}
