using Catalog.Api.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var cliente = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var database = new MongoClient(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            var product = new MongoClient(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get;  }
    }
}
