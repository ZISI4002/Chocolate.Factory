﻿using System;
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
        public bool AfterUse {  get; set; }
        public decimal InStock { get; set; }
        

    }
}
