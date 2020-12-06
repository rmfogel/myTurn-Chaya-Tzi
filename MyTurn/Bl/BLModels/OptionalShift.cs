using Bl.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
  public  class OptionalShift
    {
        public ShiftDayDetail Shift { get; set; }
        public TimeSpan AvilableTime { get; set; }
        public int ServiceId { get; set; }

    }
}
