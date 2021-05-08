using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Concrete
{
    public class CustomerRepository : ICustomerRepository, IEntityRepository<Customer>
    {
        private readonly IMongoCollection<Customer> _mongoCollection;
        public CustomerRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _mongoCollection = db.GetCollection<Customer>("Customers");
        }
        public async Task Create(Customer model)
        {
            await _mongoCollection.InsertOneAsync(model);
        }

        public async Task Delete(ObjectId objectId)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == objectId);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<Customer> GetById(ObjectId objectId)
        {
            return await _mongoCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<Customer> Update(Customer model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
