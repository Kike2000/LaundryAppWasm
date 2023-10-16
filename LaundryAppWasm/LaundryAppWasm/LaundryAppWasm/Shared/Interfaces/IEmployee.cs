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
        Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id);
        Task CreateEmployee(EmployeeDTO employeeDTO);
        Task<bool> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<bool> DeleteEmployee(Guid Id);
    }
}
