using LaundryAppWasm.Server.Controllers;
using LaundryAppWasm.Server.DBContext;
using LaundryAppWasm.Shared.DTOs;
using LaundryAppWasm.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LaundryAppWasm.Test.Employee
{
    [TestClass]
    public class EmployeeTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;
        private static ApplicationDbContext _context = null;
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _context = new ApplicationDbContext();
        }

        [TestMethod]
        public void MyTestMethod()
        {
            // Arrange
            //var calculator = new Calculator();

            //// Act
            //var result = calculator.Add(2, 3);

            //// Assert
            //Assert.AreEqual(5, result);
        }


        [TestMethod]
        public async Task Get_ReturnsOkResult_WhenEmployeesExist()
        {
            // Arrange
            var mockEmployeeInterface = new Mock<IEmployee>();
            mockEmployeeInterface.Setup(repo => repo.GetEmployeesAsync()).ReturnsAsync(new List<EmployeeDTO>
        {
            new EmployeeDTO { Id = Guid.Parse("7e11cb35-c0cc-41c3-925e-ceac9831a4a8"), FirstName = "John", LastName = "Doe" },
            new EmployeeDTO { Id = Guid.Parse("7e11cb35-c0cc-41c3-925e-ce2c9831a4a8"), FirstName = "Jane", LastName = "Smith" }
            // Add more employee data as needed
        });

            var controller = new EmployeeController(mockEmployeeInterface.Object);

            // Act
            ActionResult<IEnumerable<EmployeeDTO>> result = await controller.Get();

            var okResult = result;
            var employees =okResult.Result.ToString();
            Assert.AreEqual(2, employees.Count(), "Expected number of employees does not match actual");

        }
    }
}
