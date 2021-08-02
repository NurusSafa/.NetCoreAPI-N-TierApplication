using EmployeeBLL.Common;
using EmployeeBLL.DTOs;
using EmployeeBLL.Repositories;
using EmployeeDAL.Domains;
using EmployeeDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private IUnitOfWork _unitOfWork;
        private IEmployeeRepository _empRepo;
        public EmployeeManager(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _empRepo = employeeRepository;
        }
        public async Task<int> CreateEmployee(EmployeeDto dtoEmp)
        {
            int result = 0;
            Employee dmoEmployee = EmployeeMapper.MapDTOtoDMO(dtoEmp);
            if(dmoEmployee!= null)
            {
                _empRepo.Add(dmoEmployee);
                result = await _unitOfWork.CompleteAsync();
            }
            return result;
        }
        public async Task<List<EmployeeDto>> GetEmployees()
        {
            IEnumerable<Employee> dbEmployees = await _empRepo.GetAllAsync();
            List<Employee> lstEmployee = dbEmployees?.ToList();

            List<EmployeeDto> lstDtoEmployee = EmployeeMapper.MapDMOToDTOList(lstEmployee);

            return lstDtoEmployee;
        }
        public async Task<EmployeeDto> GetEmployee(int id)
        {
            Employee dmoEmployee = await _empRepo.GetAsync(id);

            EmployeeDto dtoEmploy =  EmployeeMapper.MapDMOtoDTO(dmoEmployee);

            return dtoEmploy;
        }  
        public async Task<int> UpdateEmployee(int id , EmployeeDto dtoEmp)
        {
            int intResult = 0;
            Employee dmoEmployee = await _empRepo.GetAsync(id);
            if(dmoEmployee!= null)
            {
                EmployeeMapper.MapDTOtoDMO(dtoEmp, dmoEmployee);

                intResult = await _unitOfWork.CompleteAsync();
            }
            return intResult;
        }     

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            Employee dmoEmployee = await _empRepo.GetAsync(id);
            if (dmoEmployee != null)
            {
                _empRepo.Remove(dmoEmployee);
                result = await _unitOfWork.CompleteAsync();
            }
            return result;
        }       
    }
}
