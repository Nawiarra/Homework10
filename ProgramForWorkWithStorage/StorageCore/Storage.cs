using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCore;

namespace StorageCore
{
    public static class Storage
    {
        private static int volume = 100;

        private static List<Product> ProductStorage = new List<Product>();

        public static string CheckProductExpiryDate(Product checkingProduct)
        {
            DateTime checkingDate = checkingProduct.baseProduct.ShowExpirationDate();

            if(checkingDate <= DateTime.Now)
            {
                ProductStorage.Remove(checkingProduct);

                return "This thing expired and will decommission";
            }

            return "This thing not expired";
        }

        public static List<string> ShowListOfProduct()
        {
            List<string> productInfo = new List<string>();

            foreach (Product product in ProductStorage)
            {
                productInfo.Add(product.ToString());
            }

            return productInfo;
        }

        public static string AddProductToStorage(Product productForAdd)
        {
            if (volume > ProductStorage.Count)
            {
                ProductStorage.Add(productForAdd);
            }
            else
            {
                return "The storage is the fullest";
            }
            return "Product was added into storage";
        }

        public static void DeleteProductToStorage(Product productForDelete)
        {
            ProductStorage.Remove(productForDelete);
        }

        public static void ExpandStorage()
        {
            volume += volume;
        }

    }
}
