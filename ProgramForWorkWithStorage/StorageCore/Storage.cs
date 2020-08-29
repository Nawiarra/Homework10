using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCore;

namespace StorageCore
{
    public class Storage
    {
        private int volume;

        private List<Product> ProductStorage = new List<Product>();

        public string CheckProductExpiryDate(Product checkingProduct)
        {
            DateTime checkingDate = checkingProduct.baseProduct.ShowExpirationDate();

            if(checkingDate <= DateTime.Now)
            {
                ProductStorage.Remove(checkingProduct);

                return "This thing expired and will decommission";
            }

            return "This thing not expired";
        }

        public List<string> ShowListOfProduct()
        {
            List<string> productInfo = new List<string>();

            foreach (Product product in ProductStorage)
            {
                productInfo.Add(product.ToString());
            }

            return productInfo;
        }

        public void AddProductToStorage(Product productForAdd)
        {
            ProductStorage.Add(productForAdd);
        }

        public void DeleteProductToStorage(Product productForDelete)
        {
            ProductStorage.Remove(productForDelete);
        }

    }
}
