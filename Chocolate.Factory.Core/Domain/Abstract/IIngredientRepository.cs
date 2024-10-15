using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IIngredientRepository
    {
        void Add(Ingredient ingredient);
        void Update(Ingredient ingredient);
        void Delete(int Id);
        Ingredient Get(int id);
        List<Ingredient> GetAll();
    }
}
