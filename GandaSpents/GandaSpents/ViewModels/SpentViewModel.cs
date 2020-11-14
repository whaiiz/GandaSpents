using GandaSpents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandaSpents.ViewModels
{
    public class SpentViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<SpentEntity> SpentEntities { get; set; }
        public Spent Spent { get; set; }
    }
}
