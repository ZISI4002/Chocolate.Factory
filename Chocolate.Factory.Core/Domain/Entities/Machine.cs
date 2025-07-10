using Chocolate.Factory.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Entities
{
    public class Machine
    {
        public int Id { get; set; }
        public MachinType MachineType { get; set; }
        public string BrandName { get; set; }
        public string SerialNumber { get; set; }
        public int HourlyElectricWaste { get; set; }
        public int UsePeriod { get; set; }
        public DateTime PurchaseDate { get; set; }


    }
}
