using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(int Id);
        Product Get(int Id);
        List<Product> GetAll();


    }
}
