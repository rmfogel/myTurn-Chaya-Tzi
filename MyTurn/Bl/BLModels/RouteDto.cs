using Bl.BLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
  public  class RouteDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public AreaRange areaRange { get; set; } = new AreaRange();
        public int walkingBy { get; set; }
        public TimeRange timeRange { get; set; } = new TimeRange();
        public List<int> businessList { get; set; }
    }
}
