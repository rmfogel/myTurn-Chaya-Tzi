using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace Bl.BLModels
{
   public class RouteAppointmentsDto
    {
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public PointOnMap StartPoint { get; set; }
        public PointOnMap EndPoint { get; set; }
        public int WalkingBy { get; set; }


        public List<AppointmentDto> Appointments { get; set; }

        public RouteAppointmentsDto(Dal.Route route)
        {
            this.StartPoint =new PointOnMap(route.StartPoint);
            this.EndPoint = new PointOnMap(route.EndPoint);
            this.StartTime = route.StartTime;
            this.EndTime = route.EndTime;
            this.WalkingBy = route.WalkingBy;
            this.UserId= route.UserId;
            this.RouteId = route.RouteId;
        }
    }
}
