using ASP.NET_Core_With_Mongo_Db.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Business.Abstract
{
    interface IAddressService
    {
        Task Create(Address model);

        Task Delete(Address model);

        Task<Address> Update(Address model);

        Task<Address> GetById(Address model);

        Task<List<Address>> GetAll();

    }
}
