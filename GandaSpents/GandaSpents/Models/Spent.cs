using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public class Spent
    {
        public string Id { get; set; }
        public string SpentEntityId { get; set; }
        public SpentEntity SpentEntity { get; set; }
        [Required]
        public string ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        // [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public double Amount { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
