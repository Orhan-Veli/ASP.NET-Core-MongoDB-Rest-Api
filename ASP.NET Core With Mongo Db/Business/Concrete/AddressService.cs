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
    public class AddressService : IAddressService
    {
        private readonly IEntityRepository<Address> _addressRepository;
        public AddressService(IEntityRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Create(Address model)
        {
            if (model == null || string.IsNullOrEmpty(model.Country) || string.IsNullOrEmpty(model.County))
            {
                throw new Exception("Model null");
            }
            await _addressRepository.Create(model);
        }

        public async Task Delete(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                throw new Exception("Model null");
            }
            await _addressRepository.Delete(objectId);
        }

        public async Task<List<Address>> GetAll()
        {
           return await _addressRepository.GetAll();
        }

        public async Task<Address> GetById(ObjectId objectId)
        {
            if (objectId == ObjectId.Empty)
            {
                throw new Exception("Model null");
            }
            return await _addressRepository.GetById(objectId);
        }

        public Task<Address> Update(Address model)
        {
            if (model == null || string.IsNullOrEmpty(model.Country) || string.IsNullOrEmpty(model.County))
            {
                throw new Exception("Model null");
            }
            return _addressRepository.Update(model);
        }
    }
}
