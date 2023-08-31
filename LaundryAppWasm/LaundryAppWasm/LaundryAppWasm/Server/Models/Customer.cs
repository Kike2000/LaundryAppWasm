using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
