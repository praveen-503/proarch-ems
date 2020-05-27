using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IEmployeeRepository: IRepository
    {
        Task<List<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int Id);
        Task<int> CreateEmployeeAsync(EmployeeModel employeeModel);
        Task<bool> DeleteEmployeeAsync(int Id);
        Task<bool> UpdateEmployeeAsync(EmployeeModel employee);
    }
}
