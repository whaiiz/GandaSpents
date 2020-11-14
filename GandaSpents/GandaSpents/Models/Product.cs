using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public class Product : Model
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
