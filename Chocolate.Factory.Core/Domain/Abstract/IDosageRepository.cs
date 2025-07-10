using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IDosageRepository
    {
     
        void Add(Dosage dosage);
        void Delete(int Id);
        Dosage Get(int Id);
        List<Dosage> GetAll();
        List<Dosage> GetByProductId(int productId);
        List<Dosage> GetByIngredientId(int ingredientId);

    }
}
