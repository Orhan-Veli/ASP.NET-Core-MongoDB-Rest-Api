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
    public class BookRepository : IBookRepository, IEntityRepository<Book>
    {
        private readonly IMongoCollection<Book> _mongoCollection;
        public BookRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _mongoCollection = db.GetCollection<Book>("Books");
        }
        public async Task Create(Book model)
        {
            await _mongoCollection.InsertOneAsync(model);
        }

        public async Task Delete(ObjectId objectId)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == objectId);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<Book> GetById(ObjectId objectId)
        {
            return await _mongoCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task<Book> Update(Book model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
