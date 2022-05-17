using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traektoria.Model
{
    public partial class Goods
    {
        public string GetPrice
        {
            get
            {
                string result = $"Цена: {Cost}";
                return result;
            }
        }
    }
}
