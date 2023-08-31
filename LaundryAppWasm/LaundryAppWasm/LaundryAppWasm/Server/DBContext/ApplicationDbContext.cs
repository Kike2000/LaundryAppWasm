using LaundryAppWasm.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace LaundryAppWasm.Server.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
