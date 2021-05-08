using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract;
using ASP.NET_Core_With_Mongo_Db.Dal;
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
        public Task Create(Writer model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Writer model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Writer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Writer> GetById(Writer model)
        {
            throw new NotImplementedException();
        }

        public Task<Writer> Update(Writer Model)
        {
            throw new NotImplementedException();
        }
    }
}
