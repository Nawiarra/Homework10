using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore
{
    public class Product: BaseProduct
    {
        public string name { get; }
        public decimal price { get; set; }


    }
}
