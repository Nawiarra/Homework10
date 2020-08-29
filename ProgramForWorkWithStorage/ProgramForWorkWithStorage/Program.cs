using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCore;
using StorageCore;
using ValidationLib;

namespace ProgramForWorkWithStorage
{
    class Program
    {
        public static decimal WriteDecimalValue(string ValueName)
        {
            decimal WritingValue;

            do
            {
                Console.WriteLine("Give me correct " + ValueName + ": ");

                WritingValue = Validation.DecimalValidation(Console.ReadLine());
            }
            while (WritingValue == int.MinValue);

            return WritingValue;
        }
        public static int WriteIntValue(string ValueName)
        {
            int WritingValue;

            do
            {
                Console.WriteLine("Give me correct " + ValueName + ": ");

                WritingValue = Validation.IntValidation(Console.ReadLine());
            }
            while (WritingValue == int.MinValue);

            return WritingValue;
        }

        public static string WriteString(string ValueName)
        {
            Console.WriteLine("Give me correct " + ValueName + ": ");

            return Console.ReadLine();
        }
        public static MenuItem WriteMenuItem(string ValueName)
        {
            int WritingValue;

            do
            {
                Console.WriteLine("Give me correct " + ValueName + ": ");

                WritingValue = Validation.IntValidation(Console.ReadLine());
            }
            while (WritingValue == int.MinValue);

            return (MenuItem)WritingValue;
        }

        public static DateTime WriteDateTimeValue(string ValueName)
        {
            DateTime WritingValue;

            do
            {
                Console.WriteLine("Give me correct " + ValueName + " in format: {0:d}", new DateTime(2020, 08, 29));

                WritingValue = Validation.DateTimeValidation(Console.ReadLine());
            }
            while (WritingValue == DateTime.MinValue);

            return WritingValue;
        }

        static void Main(string[] args)
        {
            string name;
            decimal price;
            DateTime dateOfDelivery;
            int countDayToExpirationDate;
            int numberDelOrChangeProduct;
            Product customProduct;
            MenuItem userChoice;

            do
            {
                Console.WriteLine("Press 1 to create new product,\n2 - to see all product,\n3 - to check product expirity date,\n4 - to delete item by number,\n5 - for exit ");
                userChoice = WriteMenuItem("menu item");

                Console.Clear();

                switch (userChoice)
                {
                    case MenuItem.CreateProduct:
                        {
                            name = WriteString("name");
                            price = WriteDecimalValue("price");
                            dateOfDelivery = WriteDateTimeValue("date of delivery");
                            countDayToExpirationDate = WriteIntValue("count day to expiration date");

                            customProduct = new Product(name, price, dateOfDelivery, countDayToExpirationDate);

                            Console.WriteLine(Storage.AddProductToStorage(customProduct));
                        }
                        break;
                    case MenuItem.ShowAllProducts:
                        {
                            List <string> allProducts = Storage.ShowListOfProduct();

                            foreach(string product in allProducts)
                            {
                                Console.WriteLine(product);
                            }
                        }
                        break;
                    case MenuItem.CheckProductExpiryDate:
                        {
                            numberDelOrChangeProduct = WriteIntValue($"number of checking product (index + 1)");

                            Product CheckedItem = Storage.GetItem(numberDelOrChangeProduct - 1);

                            Console.WriteLine(Storage.CheckProductExpiryDate(CheckedItem));
                        }
                        break;
                    case MenuItem.DeleteProduct:
                        {
                            numberDelOrChangeProduct = WriteIntValue($"number of delete product (index + 1)");

                            Storage.DeleteProductFromStorage(numberDelOrChangeProduct - 1);
                        }
                        break;
                    case MenuItem.Exit: 
                        {
                            return;
                        }
                    case MenuItem.DoSomethingElse:
                        {
                            Console.WriteLine("I don't understand what do you want to say me.");
                        }
                        break;
                }
            }
            while (true);

        }

        public enum MenuItem
        {
            DoSomethingElse = 0,
            CreateProduct = 1,
            ShowAllProducts = 2,
            CheckProductExpiryDate = 3,
            DeleteProduct = 4,
            Exit = 5
        }
    }
}
