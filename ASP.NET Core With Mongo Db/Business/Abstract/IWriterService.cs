using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Business.Abstract
{
    public interface IWriterService
    {
        Task Create(Writer model);

        Task Delete(ObjectId objectId);

        Task<Writer> Update(Writer model);

        Task<Writer> GetById(ObjectId objectId);

        Task<List<Writer>> GetAll();
    }
}
