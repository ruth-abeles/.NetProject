using R_home.Core.Models;
using R_home.Core.Repositories;
using R_home.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public EmployeeService(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return _EmployeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _EmployeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            return await _EmployeeRepository.AddEmployeeAsync(employee);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            return await _EmployeeRepository.UpdateEmployeeAsync(id, employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _EmployeeRepository.DeleteEmployeeAsync(id);
        }



    }
}
