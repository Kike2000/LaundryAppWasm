using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{id:guid}")]
        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid id)
        {
            try
            {
                var employeeDTO = await _employeeInterface.GetEmployeeByIdAsync(id);
                return employeeDTO;
            }
            catch (Exception ex)
            {

            }
            return null;
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

        [HttpPut]
        public async Task<ActionResult> Update(EmployeeDTO model)
        {
            try
            {
                var result = await _employeeInterface.UpdateEmployee(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _employeeInterface.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }
    }
}
