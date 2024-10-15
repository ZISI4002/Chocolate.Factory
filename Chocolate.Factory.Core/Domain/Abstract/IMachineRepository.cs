using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IMachineRepository
    {
        void Add(Machine machine);
        void Update(Machine machine);
        void Delete(int Id);

        Machine Get(int Id);
        List<Machine> GetAll();
    }
}
