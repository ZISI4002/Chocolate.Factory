using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Entities
{
    public class WorkTime
    {
        public int Id { get; set; }
        public DateTime ThisDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public int Production { get; set; }
        public bool IsInspected { get; set; }
        public Machine Machine { get; set; }



    }
}
