using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCore
{
    public class Product
    {
        public string name { get; }
        public decimal price { get; set; }

        BaseProduct baseProduct;

        Product(string name, decimal price, DateTime dateOfDelivery, int countDayToExpirationDate)
        {
            this.name = name;
            this.price = price;
            this.baseProduct = new BaseProduct(dateOfDelivery, countDayToExpirationDate);
        }

    }
}
