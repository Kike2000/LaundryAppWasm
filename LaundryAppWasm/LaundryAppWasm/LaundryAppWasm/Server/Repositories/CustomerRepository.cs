using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Threading.Tasks;


namespace LaundryAppWasm.Server.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber
            };
            try
            {
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        public Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            return await _context.Customer
            .Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                // Map other properties...
            })
            .ToListAsync();
        }

        public Task UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
