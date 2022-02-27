using Catalog.Api.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }
        public static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "6065165",
                    Name = "IPhone X",
                    Description = "Nice"
                }
            };
        }
    }
}
