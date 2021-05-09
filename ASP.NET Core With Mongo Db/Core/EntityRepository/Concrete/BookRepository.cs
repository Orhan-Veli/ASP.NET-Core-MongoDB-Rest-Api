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
    public class BookRepository : IBookRepository, IEntityRepository<Book>
    {
        private readonly IMongoCollection<Book> _mongoCollection;
        private readonly IMongoCollection<Writer> _writerCollection;

        public BookRepository(ISimpleDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);
            _mongoCollection = db.GetCollection<Book>(settings.BooksCollectionName);
            _writerCollection = db.GetCollection<Writer>(settings.WriterCollectionName);
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
