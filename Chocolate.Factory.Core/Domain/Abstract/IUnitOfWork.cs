using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }   
        IIngredientRepository IngredientRepository { get; }
        IDosageRepository DosageRepository { get; }
        IMachineRepository MachineRepository { get; }
        IWorkTimeRepository WorkTimeRepository { get; }
        ICarRepository CarRepository { get; }
        ICarWorkTimeRepository CarWorkTimeRepository { get; }

        bool CheckConnection();

    }
}
