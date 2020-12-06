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

        public static void SaveRouteToDB(RouteDto route, TurnResult result)
        {
            using (MyTurnEntities contex = new MyTurnEntities())
            {
                Dal.Route newRoute = Converters.RouteConverter.ToDal(route);
               
                    foreach (var item in result.GoodApointments)
                    {
                        newRoute.Appointments.Add(Converters.AppointmentConverter.ToDalAppointment(item));
                    }

                newRoute.EndTime = result.ActualEndTime;
                newRoute.StartTime = result.ActualStartTime;
                contex.Routes.Add(newRoute);
                contex.SaveChanges();

            }
        }
    }
}


