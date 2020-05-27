using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Usecases
{
    public interface IEmployeeUsecase : IUsecase
    {
        Task<List<EmployeeModel>> GetEmployees();
        Task<EmployeeModel> GetEmployeeById(int Id);
        Task<int> CreateEmployeeAsync(EmployeeModel employeeModel);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> UpdateEmployeeAsync(EmployeeModel employee);
    }

    internal class EmployeeUsecase : Usecase, IEmployeeUsecase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUsecase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        async Task<int> IEmployeeUsecase.CreateEmployeeAsync(EmployeeModel employee)
        {
            employee.Salt = EmployeeModel.CreateSalt();
            employee.Password = EmployeeModel.CreatePasswordHash(employee.Password, employee.Salt);
            return await _employeeRepository.CreateEmployeeAsync(employee);
        }

        async Task<bool> IEmployeeUsecase.DeleteEmployeeAsync(int Id)
        {
            return await _employeeRepository.DeleteEmployeeAsync(Id);
        }

        async Task<EmployeeModel> IEmployeeUsecase.GetEmployeeById(int Id)
        {
            return await _employeeRepository.GetEmployeeById(Id);
        }

        async Task<List<EmployeeModel>> IEmployeeUsecase.GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }

        async Task<bool> IEmployeeUsecase.UpdateEmployeeAsync(EmployeeModel employee)
        {
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
