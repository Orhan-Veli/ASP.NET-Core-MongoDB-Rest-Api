using ASP.NET_Core_With_Mongo_Db.Dal;
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

        Task Delete(Writer model);

        Task<Writer> Update(Writer model);

        Task<Writer> GetById(Writer model);

        Task<List<Writer>> GetAll();
    }
}
