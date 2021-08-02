using EmployeeBLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.Repositories
{
    public interface IEmployeeManager
    {
        public Task<List<EmployeeDto>> GetEmployees();
        public Task<EmployeeDto> GetEmployee(int id);
        public Task<int> CreateEmployee(EmployeeDto emp);
        public Task<int> UpdateEmployee(int id, EmployeeDto emp);
        public Task<int> DeleteEmployee(int id);
    }
}
