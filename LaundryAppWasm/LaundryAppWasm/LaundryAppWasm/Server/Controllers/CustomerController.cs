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
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDto model)
        {
            try
            {
                await _customerRepository.CreateCustomer(model);
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