using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerInterface;
        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context, ICustomer customerInterface)
        {
            _customerInterface = customerInterface;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Get()
        {
            try
            {
                var customers = await _customerInterface.GetCustomersAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDTO model)
        {
            try
            {
                await _customerInterface.CreateCustomer(model);
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