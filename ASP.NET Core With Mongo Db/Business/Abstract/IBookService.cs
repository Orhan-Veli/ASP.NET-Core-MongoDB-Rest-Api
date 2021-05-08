using ASP.NET_Core_With_Mongo_Db.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_With_Mongo_Db.Business.Abstract
{
    public interface IBookService
    {
        Task Create(Book model);

        Task Delete(Book model);

        Task<Book> Update(Book model);

        Task<Book> GetById(Book model);

        Task<List<Book>> GetAll();
    }
}
