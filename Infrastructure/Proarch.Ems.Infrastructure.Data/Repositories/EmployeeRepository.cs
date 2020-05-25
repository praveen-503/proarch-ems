using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmsDbContext _context;

        public EmployeeRepository(EmsDbContext context)
        {
            _context = context;
        }

        async Task<bool> IEmployeeRepository.DeleteEmployeeAsync(int Id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == Id && e.IsDelete == false).ConfigureAwait(false);
            if (employee != null)
            {
                employee.IsDelete = true;
                _context.Entry(employee).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }

                return true;
            }
            return false;
        }

        async Task<EmployeeModel> IEmployeeRepository.GetEmployeeById(int Id)
        {
            return await _context.Employees.FindAsync(Id);
        }

        async Task<List<EmployeeModel>> IEmployeeRepository.GetEmployees()
        {
           return  await _context.Employees.ToListAsync().ConfigureAwait(false);
        }

        async Task<bool> IEmployeeRepository.UpdateEmployeeAsync(EmployeeModel employee)
        {
            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(employee.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

         private bool EmployeeModelExists(int Id)
        {
            var employee = _context.Employees.SingleOrDefaultAsync(e => e.Id == Id && e.IsDelete == false);
            if(employee == null)
            {
                return false;
            }
            return true;

        }

        async Task<int> IEmployeeRepository.CreateEmployeeAsync(EmployeeModel employee)
        {
            var existedEmployee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id || e.Email == employee.Email);
            if (existedEmployee != null)
            {
                return 0;
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return employee.Id;
        }
    }
}
