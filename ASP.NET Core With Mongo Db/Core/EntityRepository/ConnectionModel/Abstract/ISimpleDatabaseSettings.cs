using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.ConnectionModel.Abstract
{
    public interface ISimpleDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string AddressCollectionName { get; set; }

        string WriterCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
