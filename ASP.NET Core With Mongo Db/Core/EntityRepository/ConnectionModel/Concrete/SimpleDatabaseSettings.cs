using ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.ConnectionModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Core.EntityRepository.ConnectionModel.Concrete
{
    public class SimpleDatabaseSettings : ISimpleDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string WriterCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
