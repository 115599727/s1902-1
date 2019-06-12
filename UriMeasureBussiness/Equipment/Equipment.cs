using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
  public abstract  class Equipment
    {
        /// <summary>
        /// 启用状态
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public string State { get; }


    }
}
