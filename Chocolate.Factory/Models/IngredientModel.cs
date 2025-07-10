using Chocolate.Factory.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Models
{
    public class IngredientModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public UseTimeType UseTime { get; set; }
        public decimal InStock { get; set; }

        

        public override string ToString()
        {
            return Name;
        }
    }
}
