using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared;
using LaundryAppWasm.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private readonly ApplicationDbContext _context;
        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            var customers = _context.Customer.ToList();
            var customerDtoList = new List<CustomerDto>();
            foreach (var item in customers)
            {
                var customerDto = new CustomerDto
                {
                    Name = item.Name,
                };
                customerDtoList.Add(customerDto);
            }
            return customerDtoList;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDto model)
        {
            try
            {
                // Create a new customer record using Entity Framework
                var customer = new Customer
                {
                    Name = model.Name,
                };
                _context.Customer.Add(customer);
                await _context.SaveChangesAsync();

                return Ok(); // or return the created customer, status code, etc.
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }
    }
}