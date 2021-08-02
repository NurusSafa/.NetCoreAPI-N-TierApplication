using EmployeeDAL.Domains;
using EmployeeDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories.Implementations
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeRecordsContext employeeContext):base(employeeContext)
        {

        }
    }
}
