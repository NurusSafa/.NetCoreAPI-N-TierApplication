using EmployeeDAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories.Interfaces
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
    }
}
