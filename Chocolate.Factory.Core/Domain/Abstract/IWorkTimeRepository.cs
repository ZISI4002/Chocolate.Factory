using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IWorkTimeRepository
    {
        void Add(WorkTime workTime);
        void Delete(int Id);
        WorkTime Get(int Id);
        List<WorkTime> GetAll();

        List<WorkTime> GetByMachineId(int MachineId);
    }
}
