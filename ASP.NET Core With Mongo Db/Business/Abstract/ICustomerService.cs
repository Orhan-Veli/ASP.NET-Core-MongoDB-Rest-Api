using ASP.NET_Core_With_Mongo_Db.Dal;
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

        Task Delete(Customer model);

        Task<Customer> Update(Customer model);

        Task<Customer> GetById(Customer model);

        Task<List<Customer>> GetAll();
    }
}
