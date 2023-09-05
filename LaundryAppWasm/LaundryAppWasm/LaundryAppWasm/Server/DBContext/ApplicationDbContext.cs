using LaundryAppWasm.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaundryAppWasm.Server.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<OrderTotal> OrderTotal { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
