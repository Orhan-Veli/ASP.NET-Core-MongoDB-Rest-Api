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
    public class AddressRepository : IAddressRepository, IEntityRepository<Address>
    {
        private readonly IMongoCollection<Address> _mongoCollection;
        public AddressRepository(ISimpleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _mongoCollection = db.GetCollection<Address>(settings.AddressCollectionName);
        }

        public async Task Create(Address model)
        {
            await _mongoCollection.InsertOneAsync(model);
        }

        public async Task Delete(ObjectId objectId)
        {
         await _mongoCollection.DeleteOneAsync(x=> x.Id == objectId);            
        }

        public async Task<List<Address>> GetAll()
        {
           return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<Address> GetById(ObjectId objectId)
        {
            return await _mongoCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<Address> Update(Address model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
