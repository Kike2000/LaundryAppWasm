using LaundryAppWasm.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppWasm.Shared.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<CustomerDTO>> GetCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task CreateCustomer(CustomerDTO customer);
        Task UpdateCustomer(CustomerDTO customer);
    }
}
