using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        Task Create(T model);

        Task Delete(ObjectId objectId);

        Task<T> Update(T model);

        Task<T> GetById(ObjectId objectId);

        Task<List<T>> GetAll();

    }
}
