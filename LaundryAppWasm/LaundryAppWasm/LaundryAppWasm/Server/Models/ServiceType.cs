using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public Item? Item { get; set; }
        public double Price { get; set; }
        [MaxLength(15)]
        public string? Type { get; set; }
    }
}
