using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Entities
{
    public class CarWorkTime
    {

        public int Id { get; set; }
        public DateTime ThisDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        public int TranslateProduction { get; set; }
        public int WastedGas {  get; set; }
        public bool IsInspected { get; set; }
        public Car Car { get; set; }
    }
}
