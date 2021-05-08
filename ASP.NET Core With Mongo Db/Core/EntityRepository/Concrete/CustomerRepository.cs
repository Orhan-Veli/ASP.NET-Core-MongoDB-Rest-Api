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
    public class CustomerRepository : ICustomerRepository, IEntityRepository<Customer>
    {
        public Task Create(Customer model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Customer model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetById(Customer model)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer Model)
        {
            throw new NotImplementedException();
        }
    }
}
