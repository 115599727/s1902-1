using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Data
{
   public class DictionaryItem
    {
        public DictionaryItem(int id, string val, string keyword)
        {
            this.ID = id;
            this.Value = val;
            this.KeyWord = keyword;
        }
        public int ID { get; set; }

        public string Value { get; set; }

        public string KeyWord { get; set; }


    }
}
