using ASP.NET_Core_With_Mongo_Db.Business.Abstract;
using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Business.Concrete
{
    public class WriterService : IWriterService
    {
        private readonly IEntityRepository<Writer> _writerRepository;
        public WriterService(IEntityRepository<Writer> writerRepository)
        {
            _writerRepository = writerRepository;
        }
        public async Task Create(Writer model)
        {
            if (model == null)
            {
                throw new Exception("Model null");
            }
            await _writerRepository.Create(model);
        }

        public async Task Delete(ObjectId objectId)
        {
            await _writerRepository.Delete(objectId);
        }

        public async Task<List<Writer>> GetAll()
        {
            return await _writerRepository.GetAll();
        }

        public Task<Writer> GetById(ObjectId objectId)
        {
            return _writerRepository.GetById(objectId);
        }

        public Task<Writer> Update(Writer model)
        {
            if (model == null)
            {
                throw new Exception("Model null");
            }
            return _writerRepository.Update(model);
        }
    }
}
