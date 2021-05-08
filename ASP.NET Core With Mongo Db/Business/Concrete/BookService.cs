using ASP.NET_Core_With_Mongo_Db.Business.Abstract;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Business.Concrete
{
    public class BookService : IBookService
    {
        private readonly IEntityRepository<Book> _bookRepository;      
        public BookService(IEntityRepository<Book> bookRepository)
        {          
            _bookRepository = bookRepository;
        }
        public async Task Create(Book model)
        {
            if (model == null)
            {
                throw new Exception("Model null");
            }            
            await _bookRepository.Create(model);          
        }

        public async Task Delete(ObjectId objectId)
        {
            await _bookRepository.Delete(objectId);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(ObjectId objectId)
        {
            return await _bookRepository.GetById(objectId);
        }

        public async Task<Book> Update(Book model)
        {
            if (model == null)
            {
                throw new Exception("Model null");
            }
            return await _bookRepository.Update(model);
        }
    }
}
