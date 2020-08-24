using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.Models
{
    public class Spent
    {
        public int Id { get; set; }
        public int SpentEntityId { get; set; }
        public SpentEntity SpentEntity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
