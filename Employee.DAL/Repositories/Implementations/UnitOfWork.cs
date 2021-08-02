using EmployeeDAL.Domains;
using EmployeeDAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeRecordsContext _context;
        private ILogger<UnitOfWork> _logger;
        public UnitOfWork(EmployeeRecordsContext context, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _logger = logger;
            Employee = new EmployeeRepository(context);
        }
        public IEmployeeRepository Employee { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<int> CompleteAsyncInTransaction(bool status)
        {
            return await _context.SaveChangesAsync(status);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
