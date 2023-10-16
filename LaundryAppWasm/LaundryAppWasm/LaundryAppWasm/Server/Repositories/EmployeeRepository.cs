using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LaundryAppWasm.Server.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateEmployee(EmployeeDTO customer)
        {
            try
            {
                _context.Employee.Add(new Models.Employee
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Position = customer.Position,
                    Email = customer.Email
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Employee
            .Select(c => new EmployeeDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Position = c.Position,
                Email = c.Email
            }).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            return await _context.Employee
           .Select(c => new EmployeeDTO
           {
               Id = c.Id,
               FirstName = c.FirstName,
               LastName = c.LastName,
               Position = c.Position,
               Email = c.Email
           })
            .ToListAsync();
        }

        public async Task<bool> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                Employee employee = await _context.Employee.SingleOrDefaultAsync(p => p.Id == employeeDTO.Id);
                employee.FirstName = employeeDTO.FirstName;
                employee.LastName = employeeDTO.LastName;
                employee.Position = employeeDTO.Position;
                employee.Email = employeeDTO.Email;
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployee(Guid id)
        {
            var employee = _context.Employee.FirstOrDefault(p => p.Id == id);
            _context.Employee.Remove(employee);
            _context.SaveChangesAsync().Wait();
            return true;
        }

    }
}
