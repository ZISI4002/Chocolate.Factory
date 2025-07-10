using Chocolate.Factory.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public UseTimeType UseTime {  get; set; }
        public decimal InStock { get; set; }
        

    }
}
