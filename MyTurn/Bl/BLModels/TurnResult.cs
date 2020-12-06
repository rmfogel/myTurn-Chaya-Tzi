using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
  public class TurnResult
    {
        public List<AppointmentDto> GoodApointments { get; set; } = new List<AppointmentDto>();
        public List<AppointmentDto> NotGoodRange { get; set; } = new List<AppointmentDto>();
        public List<AppointmentDto> NoFree { get; set; } = new List<AppointmentDto>();
        public PointOnMap Origion { get; set; }
        public PointOnMap Destination { get; set; }
        public TimeSpan ActualStartTime { get; set; }
        public TimeSpan ActualEndTime { get; set; }

     
    }
}
