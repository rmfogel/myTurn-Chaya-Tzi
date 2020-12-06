using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class ShiftDayDetailsDto
    {
        public int id { get; set; }
        public Nullable<int> shiftId { get; set; }
        public int dayName { get; set; }
        public Nullable<System.TimeSpan> openTime { get; set; }
        public Nullable<System.TimeSpan> ClosedTime { get; set; }
        public Nullable<double> avgServiceTime { get; set; }
        public Nullable<double> zGrade { get; set; }
    }
}
