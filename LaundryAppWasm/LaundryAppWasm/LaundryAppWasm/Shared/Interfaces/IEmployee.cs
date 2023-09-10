using LaundryAppWasm.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryAppWasm.Shared.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task CreateEmployee(EmployeeDTO customer);
        Task UpdateEmployee(EmployeeDTO customer);
    }
}
