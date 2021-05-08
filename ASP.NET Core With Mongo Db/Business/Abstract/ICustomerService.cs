using ASP.NET_Core_With_Mongo_Db.Dal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Business.Abstract
{
    public interface ICustomerService
    {
        Task Create(Customer model);

        Task Delete(ObjectId objectId);

        Task<Customer> Update(Customer model);

        Task<Customer> GetById(ObjectId objectId);

        Task<List<Customer>> GetAll();
    }
}
