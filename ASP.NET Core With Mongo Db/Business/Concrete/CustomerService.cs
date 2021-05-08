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
    public class CustomerService : ICustomerService
    {
        private readonly IEntityRepository<Customer> _customerRepository;       
        public CustomerService(IEntityRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task Create(Customer model)
        {
            await _customerRepository.Create(model);
        }

        public async Task Delete(ObjectId objectId)
        {
            await _customerRepository.Delete(objectId);
        }

        public async Task<List<Customer>> GetAll()
        {
           return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetById(ObjectId objectId)
        {
           return await _customerRepository.GetById(objectId);
        }

        public async Task<Customer> Update(Customer model)
        {
            if (model == null)
            {
                throw new Exception("Model null");
            }
            return await _customerRepository.Update(model);
        }
    }
}
