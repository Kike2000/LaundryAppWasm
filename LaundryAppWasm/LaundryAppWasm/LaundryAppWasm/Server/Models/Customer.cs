﻿using System.ComponentModel.DataAnnotations;

namespace LaundryAppWasm.Server.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
