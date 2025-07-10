using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface ICarWorkTimeRepository
    {
        void Add(CarWorkTime carWorkTime);
        void Delete(int Id);
        CarWorkTime Get(int Id);
        List<CarWorkTime> GetAll();

        List<CarWorkTime> GetByCarId(int CarId);
    }
}
