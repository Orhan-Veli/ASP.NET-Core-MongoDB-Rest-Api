using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Concrete
{
    public class AddressRepository : IAddressRepository, IEntityRepository<Address>
    {
        private readonly IMongoCollection<Address> _mongoCollection;
        public AddressRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _mongoCollection = db.GetCollection<Address>("Addresses");
        }

        public async Task Create(Address model)
        {
            await _mongoCollection.InsertOneAsync(model);
        }

        public async Task Delete(Address model)
        {
         await _mongoCollection.DeleteOneAsync(x=> x.Id == model.Id);            
        }

        public async Task<List<Address>> GetAll()
        {
           return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<Address> GetById(Address model)
        {
            return await _mongoCollection.Find(x => x.Id == model.Id).FirstOrDefaultAsync();
        }

        public async Task<Address> Update(Address model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
