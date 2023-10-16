using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public string Email { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
