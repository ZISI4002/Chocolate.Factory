using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Entities
{
    public class Dosage
    {
        public int Id { get; set; }
        public decimal Duantity { get; set; }
        public decimal Deviation { get; set; }
        public Product Product { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
