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
        private readonly IMongoCollection<Writer> _writerCollection;

        public BookRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _mongoCollection = db.GetCollection<Book>("Books");
            _writerCollection = db.GetCollection<Writer>("Writers");
        }
        public async Task Create(Book model)
        {
            await _mongoCollection.InsertOneAsync(model);
            await _writerCollection.InsertOneAsync(model.Writer);
        }

        public async Task Delete(ObjectId objectId)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == objectId);
        }

        public async Task<List<Book>> GetAll()
        {
            var books = await _mongoCollection.Find(x => true).ToListAsync();
            foreach (var item in books)
            {
                item.Writer = await _writerCollection.Find(x => x.Id == item.WriterId).FirstOrDefaultAsync();               
            }
            return books;

        }

        public async Task<Book> GetById(ObjectId objectId)
        {
            var book =  await _mongoCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();

            book.Writer = await _writerCollection.Find(x => x.Id == book.WriterId).FirstOrDefaultAsync();

            return book;
        }

        public async Task<Book> Update(Book model)
        {
            return await _mongoCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
