﻿using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
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
    public class WriterRepository : IWriterRepository, IEntityRepository<Writer>
    {
        private readonly IMongoCollection<Writer> _WriterCollection;
        private readonly IMongoCollection<Address> _AddressCollection;
        private readonly IMongoCollection<Book> _bookCollection;
        public WriterRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            var db = client.GetDatabase("MongoDBContext");
            _WriterCollection = db.GetCollection<Writer>("Writers");
            _AddressCollection = db.GetCollection<Address>("Addresses");
            _bookCollection = db.GetCollection<Book>("Books");

        }
        public async Task Create(Writer model)
        {
            await _WriterCollection.InsertOneAsync(model);
            await _AddressCollection.InsertOneAsync(model.Address);
            await _bookCollection.InsertManyAsync(model.Books);
        }

        public async Task Delete(ObjectId objectId)
        {
            await _WriterCollection.DeleteOneAsync(x => x.Id == objectId);
        }

        public async Task<List<Writer>> GetAll()
        {
           var writers = await _WriterCollection.Find(x => true).ToListAsync();
            foreach (var item in writers)
            {
                if (item.AddressId != null)
                {
                    item.Address = await _AddressCollection.Find(x => x.Id == item.AddressId).FirstOrDefaultAsync(); 
                }
                if(item.BookIds != null)
                {
                    item.Books = await _bookCollection.Find(x => item.BookIds.Contains(x.Id)).ToListAsync();
                }
                
            }
            return writers;
        }

        public async Task<Writer> GetById(ObjectId objectId)
        {
           var writer = await _WriterCollection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
            if (writer.AddressId != null)
            {
                writer.Address = await _AddressCollection.Find(x => x.Id == writer.AddressId).FirstOrDefaultAsync();
            }
            if (writer.BookIds != null)
            {
                writer.Books = await _bookCollection.Find(x => writer.BookIds.Contains(x.Id)).ToListAsync();
            }
            
            return writer;
        }

        public async Task<Writer> Update(Writer model)
        {
            return await _WriterCollection.FindOneAndReplaceAsync(x => x.Id == model.Id, model);
        }
    }
}
