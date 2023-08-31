using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Models
{
    public class Service
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(60)]
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
