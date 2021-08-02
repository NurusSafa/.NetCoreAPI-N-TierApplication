using EmployeeBLL.Managers;
using EmployeeBLL.Repositories;
using EmployeeDAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBLL.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, string connection)
        {
            services.AddDataAccess(connection);
            services.AddScoped<IEmployeeManager, EmployeeManager>();           
            return services;
        }
    }
}
