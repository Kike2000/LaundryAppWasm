using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace LaundryAppWasm.Server.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(CustomerDTO customerDto)
        {
            var customer = new Customer
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
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

        public Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerDTO>> GetCustomersAsync()
        {
            return await _context.Customer
            .Select(c => new CustomerDTO
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
            })
            .ToListAsync();
        }

        public Task UpdateCustomer(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }

        Task<CustomerDTO> ICustomer.GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
