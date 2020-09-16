using ECommerce.Contracts;
using System.Collections.Generic;

namespace ECommerce.Provider
{
    public class ProductHelper
    {
        private static readonly Dictionary<string, Product> products = new Dictionary<string, Product>
        {
            {
                Constants.A,
                new Product
                {
                    Id = 1,
                    Name ="A",
                    Price = 50
                }
            },
            {
                Constants.B,
                new Product
                {
                    Id = 2,
                    Name ="B",
                    Price = 30
                }
            },
            {
                Constants.C,
                new Product
                {
                    Id = 3,
                    Name ="C",
                    Price = 20
                }
            },
            {
                Constants.D,
                new Product
                {
                    Id = 4,
                    Name ="D",
                    Price = 15
                }
            }
        };


        public static Product Get(string productName)
        {
            return products[productName];
        }

        public static List<Product> GetProducts(params string[] productNames)
        {
            var requestedProducts = new List<Product>();

            foreach (var productName in productNames)
            {
                requestedProducts.Add(products[productName]);
            }

            return requestedProducts;
        }
    }
}
