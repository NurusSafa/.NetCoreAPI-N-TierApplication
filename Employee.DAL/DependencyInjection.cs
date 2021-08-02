using EmployeeDAL.Domains;
using EmployeeDAL.Repositories.Implementations;
using EmployeeDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connection)
        {
            services.AddDbContext<EmployeeRecordsContext>(options =>
            {
                options.UseSqlServer(connection);
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
