using LaundryAppWasm.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppWasm.Shared.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task CreateCustomer(CustomerDto customer);
        Task UpdateCustomer(CustomerDto customer);
    }
}
