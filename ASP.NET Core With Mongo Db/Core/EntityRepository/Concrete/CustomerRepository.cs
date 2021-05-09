using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.ConnectionModel.Abstract;
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
        private readonly IMongoCollection<Address> _addressCollection;
        public CustomerRepository(ISimpleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _mongoCollection = db.GetCollection<Customer>(settings.CustomerCollectionName);
            _addressCollection = db.GetCollection<Address>(settings.AddressCollectionName);
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
            var customers = await _mongoCollection.Find(x => true).ToListAsync();
            foreach (var item in customers)
            {
                item.Address = await _addressCollection.Find(x => x.Id == item.AddressId).FirstOrDefaultAsync();
            }
            return customers;
        }

        public async Task<Customer> GetById(ObjectId objectId)
        {
            var customer = await _mongoCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
            if (customer != null)
            {
                customer.Address = await _addressCollection.Find(x => x.Id == customer.AddressId).FirstOrDefaultAsync();
            }
            return customer;
        }

        public async Task<Customer> Update(Customer model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
