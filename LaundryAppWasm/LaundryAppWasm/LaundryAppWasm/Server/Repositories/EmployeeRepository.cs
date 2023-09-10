using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;

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
                    Position = customer.Position
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }

        public Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(EmployeeDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}
