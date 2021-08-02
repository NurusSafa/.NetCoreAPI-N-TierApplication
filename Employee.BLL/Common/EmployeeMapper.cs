using EmployeeBLL.DTOs;
using EmployeeDAL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.Common
{
    public static class EmployeeMapper
    {
        internal static List<EmployeeDto> MapDMOToDTOList(List<Employee> lstEmployee)
        {
            List<EmployeeDto> lstDtoEmploy = null;
            if (lstEmployee != null)
            {
                lstDtoEmploy = new List<EmployeeDto>();
                for (int i = 0; i < lstEmployee.Count; i++)
                {
                    EmployeeDto dtoEmployee = new EmployeeDto();
                    dtoEmployee.FN = lstEmployee[i].FirstName;
                    dtoEmployee.MN = lstEmployee[i].MiddleName;
                    dtoEmployee.LN = lstEmployee[i].LastName;

                    lstDtoEmploy.Add(dtoEmployee);
                }
            }

            return lstDtoEmploy;
        }
        internal static void MapDTOtoDMO(EmployeeDto dtoEmp, Employee dmoEmployee)
        {
            dmoEmployee.FirstName = dtoEmp.FN;
            dmoEmployee.MiddleName = dtoEmp.MN;
            dmoEmployee.LastName = dtoEmp.LN;
        }
        internal static EmployeeDto MapDMOtoDTO(Employee dmoEmployee)
        {
            EmployeeDto dtoEmploy = null;
            if (dmoEmployee != null)
            {
                dtoEmploy = new EmployeeDto();
                dtoEmploy.FN = dmoEmployee.FirstName;
                dtoEmploy.MN = dmoEmployee.MiddleName;
                dtoEmploy.LN = dmoEmployee.LastName;
            }
            return dtoEmploy;
        }

        internal static Employee MapDTOtoDMO(EmployeeDto dtoEmp)
        {
            Employee dmoEmployee = null;
            if (dtoEmp != null)
            {
                dmoEmployee = new Employee();
                dmoEmployee.FirstName = dtoEmp.FN;
                dmoEmployee.MiddleName = dtoEmp.MN;
                dmoEmployee.LastName = dtoEmp.LN;
            }
            return dmoEmployee;
        }
    }
}
