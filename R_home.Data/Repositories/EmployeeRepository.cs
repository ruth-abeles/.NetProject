using Microsoft.EntityFrameworkCore;
using R_home.Core.Models;
using R_home.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        //Get all
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.employees.ToListAsync();
        }

        //Get by id
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee= await _context.employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return null;
            return employee;
        }

        //Add
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        //Update
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var employeeToUpdate = _context.employees.ToList().Find(e => e.Id == id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.Description = employee.Description;
                employeeToUpdate.Phon = employee.Phon;
                await _context.SaveChangesAsync();
                return employeeToUpdate;
            }
            return null;
        }

        //Delete
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = _context.employees.ToList().Find(e => e.Id == id);
            if (employee != null)
                _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
