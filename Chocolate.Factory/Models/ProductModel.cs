using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Models
{
   public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public decimal StandartWeight { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
