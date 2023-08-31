using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Server.Models;
using LaundryAppWasm.Shared;
using LaundryAppWasm.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LaundryAppWasm.Server.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
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

        [HttpGet("GetAll")]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerDto model)
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
    }
}