using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Converters
{
    public class RouteConverter
    {
        public static Route ToRoute(RouteDto route)
        {
            Route r = new Route();
            r.areaRange = route.areaRange;
            r.UserId = route.userId;
            r.timeRange = route.timeRange;
            r.walkingBy = route.walkingBy;
           r.businesses = Converters.ChoosenBusinessConverter.ToChoosenBusinessList(route.businessList);
            return r;
        }

        public static RouteDto ToRouteDto(Dal.Route route)
        {
            RouteDto r = new RouteDto();
            r.areaRange.startingPoint = route.StartPoint;
            r.areaRange.destinationPoint = route.EndPoint;
            r.timeRange.StartingTime =route.Date+ route.StartTime;
            r.timeRange.EndTime = route.Date + route.EndTime;
            r.walkingBy = route.WalkingBy;

            r.userId = route.UserId;
            r.businessList = route.Appointments.Select(a => a.ShiftDayDetail.Shift.idService.Value).ToList();
            
              return r;
        }

        public static Dal.Route ToDal(RouteDto route)
        {
            Dal.Route r = new Dal.Route();
            r.StartTime = route.timeRange.StartingTime.Value.TimeOfDay;
            r.EndTime = route.timeRange.EndTime.Value.TimeOfDay;
            r.Date = route.timeRange.StartingTime.Value.Date;
             r.EndPoint= route.areaRange.destinationPoint ;
            r.StartPoint = route.areaRange.startingPoint;
            r.WalkingBy = route.walkingBy;

            r.UserId = route.userId;

            return r;
        }
    }
}
