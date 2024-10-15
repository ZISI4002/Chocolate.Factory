using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface ICarRepository
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(int Id);
        Car Get(int Id);
        List<Car> GetAll();

    }
}
