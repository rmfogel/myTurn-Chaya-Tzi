using Bl.Dal;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.BLModels
{
    public class RouteBL
    {
        public static List<RouteAppointmentsDto> GetUsersRoutes(int userId)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {
                return contex.Routes.Where(r => r.UserId == userId).ToList().Select(r =>

                    new RouteAppointmentsDto(r)
                    {
                        //Route = Bl.Converters.RouteConverter.ToRouteDto(r),
                        Appointments = r.Appointments.ToList().Select(a => Converters.AppointmentConverter.ToDtoAppointment(a)).ToList()

                    }

               ).ToList();

            }
        }

        public static List<int> SaveRouteToDB(RouteDto route, TurnResult result)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {
                Dal.Route newRoute = Converters.RouteConverter.ToDal(route);
               
                    foreach (var item in result.GoodApointments)
                    {
                    if(item.hour!=null)
                        newRoute.Appointments.Add(Converters.AppointmentConverter.ToDalAppointment(item));
                    }

                newRoute.EndTime = result.ActualEndTime;
                newRoute.StartTime = result.ActualStartTime;
                contex.Routes.Add(newRoute);
                contex.SaveChanges();

                return newRoute.Appointments.Select(a => a.id).ToList();
            }
        }

        public static TurnResult UpdateRoute(RouteDto route)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {

                Bl.Route routeM = Converters.RouteConverter.ToRoute(route);
               Bl.Dal.Route routeDal = contex.Routes.FirstOrDefault(r=>r.RouteId==route.id);
                contex.Appointments.RemoveRange(routeDal.Appointments);
                contex.SaveChanges();
                contex.Routes.Remove(routeDal);
                contex.SaveChanges();
                TurnResult res = Bl.Calcs.CalcRoute.Calc(routeM);
                route.id = 0;
                List<int> ids = Bl.BLModels.RouteBL.SaveRouteToDB(route, res);
                for (int i = 0; i < ids.Count; i++)
                {
                    res.GoodApointments[i].id = ids[i];

                }
                return res;
            }
        }
    }
}


