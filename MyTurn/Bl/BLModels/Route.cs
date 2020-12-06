using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public enum WalkingBy { Foot=1,Car=2}
   public class Route
    {

        public int UserId { get; set; }
        public AreaRange areaRange { get; set; }
            public int walkingBy { get; set; }
            public TimeRange timeRange { get; set; }
            public List<ChoosenBusiness> businesses { get; set; }
        
    }
}
