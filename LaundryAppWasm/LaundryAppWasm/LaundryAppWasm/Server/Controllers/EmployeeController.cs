using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeInterface;
        public EmployeeController(IEmployee employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            try
            {
                var customers = await _employeeInterface.GetEmployeesAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO model)
        {
            try
            {
                await _employeeInterface.CreateEmployee(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }
    }
}
