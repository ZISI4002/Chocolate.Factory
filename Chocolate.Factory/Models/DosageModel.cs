using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Models
{
    public class DosageModel
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Deviation { get; set; }
        public string ProductName { get; set; }
        public string IngredientName { get; set; }
    }
}
