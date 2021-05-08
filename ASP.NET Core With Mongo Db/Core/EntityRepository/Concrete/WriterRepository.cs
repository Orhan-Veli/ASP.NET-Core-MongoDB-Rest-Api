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
    public class WriterRepository : IWriterRepository, IEntityRepository<Writer>
    {
        private readonly IMongoCollection<Writer> _mongoCollection;
        public WriterRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _mongoCollection = db.GetCollection<Writer>("Writers");
        }
        public async Task Create(Writer model)
        {
            await _mongoCollection.InsertOneAsync(model);
        }

        public async Task Delete(Writer model)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == model.Id);
        }

        public async Task<List<Writer>> GetAll()
        {
            return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<Writer> GetById(Writer model)
        {
            return await _mongoCollection.Find(x => x.Id == model.Id).FirstOrDefaultAsync();
        }

        public async Task<Writer> Update(Writer model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
