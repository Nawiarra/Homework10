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

        public BaseProduct baseProduct;

        public Product(string name, decimal price, DateTime dateOfDelivery, int countDayToExpirationDate)
        {
            this.name = name;
            this.price = price;
            this.baseProduct = new BaseProduct(dateOfDelivery, countDayToExpirationDate);
        }

        public override string ToString()
        {
            return $"Name: {this.name}.\nPrice: {this.price}.\nExpiration Date: {this.baseProduct.ShowExpirationDate()} ";
        }

    }
}
