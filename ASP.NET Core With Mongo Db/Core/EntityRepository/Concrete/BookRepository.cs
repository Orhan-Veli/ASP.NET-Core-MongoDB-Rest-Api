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
    public class BookRepository : IBookRepository, IEntityRepository<Book>
    {
        private readonly IMongoCollection<Book> _mongoCollection;
        public BookRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _mongoCollection = db.GetCollection<Book>("Books");
        }
        public Task Create(Book model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Book model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(Book model)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(Book Model)
        {
            throw new NotImplementedException();
        }
    }
}
