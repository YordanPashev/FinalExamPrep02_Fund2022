using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp41
{
    class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<string>();
        }
        public string Name { get; set; }
        public decimal Money { get; set; }
        public List<string> Products { get; set; }

        public override string ToString()
        {
            return $"{this.Name} - {string.Join(", ", Products)}";
        }
    }
    class Product
    {
        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfAllPersons = new List<Person>();
            List<Product> listOfAllProducts = new List<Product>();

            GetDataForAllPersons(listOfAllPersons, listOfAllProducts);
            GetDataForAllProducts(listOfAllPersons, listOfAllProducts);

            string cmd;

            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string nameOfThePurchaser = cmdArgs[0];
                string productName = cmdArgs[1];

                if (HasEnoughMoneyToBuy(listOfAllPersons, listOfAllProducts,
                                         nameOfThePurchaser, productName))
                {
                    BuyTheProduct(listOfAllPersons, listOfAllProducts,
                                  nameOfThePurchaser, productName);
                    Console.WriteLine($"{nameOfThePurchaser} bought {productName}");
                }

                else
                {
                    Console.WriteLine($"{nameOfThePurchaser} can't afford {productName}");
                }
            }

            DisplayResultAfterShopingSpree(listOfAllPersons);
        }

        static void GetDataForAllPersons(List<Person> listOfAllPersons, List<Product> listOfAllProducts)
        {
            string[] personsData = Console.ReadLine()
                 .Split(';', StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            int numberOfPersons = personsData.Length;

            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] personData = personsData[i]
                            .Split('=', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);

                Person person = new Person(name, money);
                listOfAllPersons.Add(person);
            }
        }

        static void GetDataForAllProducts(List<Person> listOfAllPersons, List<Product> listOfAllProducts)
        {
            string[] productData = Console.ReadLine()
                 .Split(';', StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            int numberOfProducts = productData.Length;

            for (int i = 0; i < productData.Length; i++)
            {
                string[] personData = productData[i]
                            .Split('=', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                string name = personData[0];
                decimal price = decimal.Parse(personData[1]);

                Product product = new Product(name, price);
                listOfAllProducts.Add(product);
            }
        }

        static bool HasEnoughMoneyToBuy(List<Person> listOfAllPersons, List<Product> listOfAllProducts,
                                        string nameOfThePurchaser, string productName)
        {
            Person purchasor = listOfAllPersons.Find(n => n.Name == nameOfThePurchaser);
            Product product = listOfAllProducts.Find(p => p.Name == productName);

            decimal purchasorCash = purchasor.Money;
            decimal currProductPrice = product.Price;

            if (purchasorCash >= currProductPrice)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        static void BuyTheProduct(List<Person> listOfAllPersons, List<Product> listOfAllProducts,
                                       string nameOfThePurchaser, string productName)
        {
            Person purchasor = listOfAllPersons.Find(n => n.Name == nameOfThePurchaser);
            Product product = listOfAllProducts.Find(p => p.Name == productName);

            decimal purchasorCash = purchasor.Money;
            decimal currProductPrice = product.Price;

            purchasor.Money -= currProductPrice;
            purchasor.Products.Add(productName);
        }

        static void DisplayResultAfterShopingSpree(List<Person> listOfAllPersons)
        {

            foreach (Person person in listOfAllPersons)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }

                else
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}