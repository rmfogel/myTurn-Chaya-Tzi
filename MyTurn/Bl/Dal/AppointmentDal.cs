using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Dal
{
    public class AppointmentDal
    {
        public static List<Appointment> GetAppointments()
        {
            using (MyTurnEntities ctx = new MyTurnEntities())
            {
                return ctx.Appointments.ToList();
            }
        }


        public static Appointment GetAppointment(int id)
        {
            try
            {
                using (MyTurnEntities ctx = new MyTurnEntities())
                {
                    Appointment appointment = ctx.Appointments.FirstOrDefault(u => u.id == id);
                    if (appointment != null)
                        return appointment;
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int CreateAppointment(Dto.AppointmentDto appointment)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    Appointment a1 = new Appointment()
                    { BranchDayId = appointment.Day.id, DurationService = appointment.DurationService, dateTimeTurn = appointment.hour, id = appointment.id, getServiceDate = appointment.hour, userId = appointment.userId };
                    contex.Appointments.Add(a1);
                    contex.SaveChanges();
                    return a1.id;
                }
            }
            catch (Exception e)
            {
                //todo
                throw;
            }


        }

        public static void UpdateUser(Dto.UserDto user)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    User q = contex.Users.FirstOrDefault(u => u.id == user.id);
                    if (q != null)
                    {
                        q.id = user.id;
                        q.firstName = user.firstName;
                        q.lastName = user.lastName;
                        q.email = user.email;
                        q.phoneNumber = user.phoneNumber;
                        contex.SaveChanges();
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void deleteUser(Dto.UserDto user)
        {
            try
            {
                using (MyTurnEntities contex = new MyTurnEntities())
                {
                    User q = contex.Users.FirstOrDefault(u => u.id == user.id);
                    if (q != null)
                        contex.Users.Remove(q);
                    contex.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
