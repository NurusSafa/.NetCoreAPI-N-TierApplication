using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        public IEmployeeRepository Employee { get;}
        Task<int> CompleteAsync();
        Task<int> CompleteAsyncInTransaction(bool status);
    }
}
