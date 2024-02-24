using MongoDB.Driver;
using Server.db;
using Server.Models;

namespace Server.Repository
{
    public class ProductsRepository
    {
        public IMongoCollection<Product> products;

        public ProductsRepository(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = mongoClient.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            products = database.GetCollection<Product>(configuration["DatabaseSettings:DatabaseName"]);
            checkIfThereIsDataInDatabase(products);
        }

        private void checkIfThereIsDataInDatabase(IMongoCollection<Product> products)
        {
            if (products == null)
            {
                throw new NullReferenceException();
            }

            if (!products.Find(p => true).Any())
            {
                products.InsertManyAsync(ProductContext.products);
            }
        }
    }
}
