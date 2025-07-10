using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Models
{
    public class WorkTimeModel
    {
        public int Id { get; set; }
        public DateTime ThisDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public int Production { get; set; }
        public bool IsInspected { get; set; }
        public string MachineSerialNumber { get; set; }




       
    }
}
