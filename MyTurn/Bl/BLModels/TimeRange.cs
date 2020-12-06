using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
   public class TimeRange
    {
        public DateTime?  StartingTime { get; set; }

        public DateTime ?  EndTime { get; set; }


        public int MinutesInRange
        {
            get { return (int)(EndTime.Value - StartingTime.Value).TotalMinutes; }
        }


    }
}
