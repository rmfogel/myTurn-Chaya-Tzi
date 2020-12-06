
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;
using Bl.BLModels;

namespace Bl
{
    public class ApointmentBl
    {

       
        public static bool IsAvailableTurn(ShiftDayDetail requiredDay, TimeRange timeRange)
        {

            TimeSpan start = GetStartTime(requiredDay, timeRange.StartingTime.Value.TimeOfDay);
            TimeSpan end = GetEndTime(requiredDay, timeRange.EndTime.Value.TimeOfDay);
            var appointments = AppointmentsListInRange(requiredDay, timeRange, start, end);
                  

            int numTurnes = (int)((end - start).TotalMinutes / requiredDay.avgServiceTime.Value);

            return appointments.Count < numTurnes;

        }

        private static TimeSpan GetStartTime(ShiftDayDetail requiredDay, TimeSpan? startingTime)
        {
            if (startingTime == null)
                throw new Exception("startingTime is null");
           return requiredDay.openTime < (TimeSpan)startingTime ? (TimeSpan)startingTime : requiredDay.openTime.Value;

        }

        private static TimeSpan GetEndTime(ShiftDayDetail requiredDay, TimeSpan? endTime)
        {
            if (endTime == null)
                throw new Exception("endTime is null");
            return requiredDay.ClosedTime > (TimeSpan)endTime ? (TimeSpan)endTime : requiredDay.ClosedTime.Value;


        }
        private static List<Appointment> AppointmentsListInRange(ShiftDayDetail requiredDay, TimeRange timeRange,TimeSpan start, TimeSpan end)
        {
          
            var appointments = requiredDay.Appointments.Where(d => d.dateTimeTurn.Value.Date == timeRange.StartingTime.Value.Date)?
                .Where(d => d.dateTimeTurn.Value.TimeOfDay >= start && d.dateTimeTurn.Value.TimeOfDay < end)?.ToList();
            return appointments;
                }
        public static TimeSpan? GetFirstAvailableTurn(ShiftDayDetail requiredDay, TimeRange timeRange,bool desc=false)
        {
            //var appointments = day.Appointments.Where(ap => ap.hour.Value.Date == range.startingTime.Date).OrderBy(d => d.hour.Value.TimeOfDay).ToList();

            TimeSpan start = GetStartTime(requiredDay, timeRange.StartingTime.Value.TimeOfDay);
            TimeSpan end = GetEndTime(requiredDay, timeRange.EndTime.Value.TimeOfDay);
            List<Appointment> appointments = AppointmentsListInRange(requiredDay, timeRange, start, end);
            if(!desc)
                appointments= appointments.OrderBy(d => d.dateTimeTurn.Value.TimeOfDay).ToList();
            else
                appointments = appointments.OrderByDescending(d => d.dateTimeTurn.Value.TimeOfDay).ToList();

            int minutes = (int)((start - requiredDay.openTime).Value.TotalMinutes % requiredDay.avgServiceTime.Value);
            if(minutes!=0)
            minutes = (int)requiredDay.avgServiceTime.Value - minutes;
            TimeSpan time= start.Add(new TimeSpan(0, minutes, 0));


            for (int i = 0; i <appointments.Count; i++,time=time.Add(new TimeSpan(0, (int)requiredDay.avgServiceTime.Value, 0)) )
            {
                if ((appointments.ElementAt(i).dateTimeTurn.Value).TimeOfDay > time)
                   
                    return time;
            }
            //TimeSpan? later=null;
            //TimeSpan? earlier = null;
            
            //todo: להחזיר null?
            if (appointments.Count==0)
            return time;
            TimeSpan lastApointment = appointments.Last().dateTimeTurn.Value.TimeOfDay;
            if (lastApointment == time.Add(new TimeSpan(0, -1*(int)requiredDay.avgServiceTime.Value, 0)) && time.Add(new TimeSpan(0, (int)requiredDay.avgServiceTime.Value, 0)) < requiredDay.ClosedTime)
                return time;
            return null;

            //else
            //{
            //    if (start == timeRange.StartingTime.Value.TimeOfDay)
            //    {
            //        timeRange.StartingTime =timeRange.StartingTime.Value.Date+ requiredDay.openTime;
            //         earlier = GetFirstAvailableTurn(requiredDay, timeRange);
                   
            //    }
            //    if (earlier != null)
            //        return earlier;

            //    else if (end == timeRange.EndTime.Value.TimeOfDay)
            //    {
            //        timeRange.EndTime = timeRange.EndTime.Value.Date + requiredDay.ClosedTime;
            //         later = GetFirstAvailableTurn(requiredDay, timeRange);
                    
            //    }

            //    if (later != null)
            //        return later;
            //    else if (numDaysAdded == 7)
            //        return null;
            //    else
            //    {
            //        //timeRange.EndTime = timeRange.EndTime.Value.Date.AddDays(1);
            //        //timeRange.StartingTime = timeRange.StartingTime.Value.Date.AddDays(1);
            //        //var newDay = 
            //        //if(newDay!=null)
            //        return GetFirstAvailableTurn(requiredDay, timeRange, ++numDaysAdded);
            //    }
            //}
        }

        public static List<Dto.AppointmentDto> MakeApointmentsList(List<OptionalShift> dicRoute)
        {
            List<Dto.AppointmentDto> appointmentList = new List<AppointmentDto>();
            foreach (var item in dicRoute)
            {
                //todo: נאבד הuserid
                Dto.AppointmentDto appointment = MakeAppointment(item);
                appointmentList.Add(appointment);
            }
            return appointmentList;
        }
         public static Dto.AppointmentDto MakeAppointment(OptionalShift optionalShift)
        {
            Route route = Calcs.CalcRoute.Route;
            AppointmentDto appointment = new AppointmentDto();

            //appointment.dayId = day.id;
            appointment.userId = route.UserId;
            appointment.Bussiness = Converters.BusinessConverter.ToDtoBusiness(optionalShift.Shift.Shift.Branch.Business);
            appointment.Service = Converters.ServiceConverter.ToDtoService(Dal.ServiceDal.GetServiceById(optionalShift.ServiceId));
            //todo:צירוף היום והשעה משני אוביקטים
           

            appointment.hour = route.timeRange.StartingTime.Value.Date + optionalShift.AvilableTime;
                //new DateTime(year, month, day1, optionalShift.AvilableTime.Hours, optionalShift.AvilableTime.Minutes, optionalShift.AvilableTime.Seconds); 
            appointment.Address=new PointOnMap {formatedAddress= optionalShift.Shift.Shift.Branch.adress};
            appointment.Day =Converters.ShiftDetailConverter.ToDtoShiftDetail( optionalShift.Shift);
            return appointment;
        }

        public static DateTime? GetClosesedApointment(TimeRange range,ShiftDayDetail shiftDetails)
        {
            DateTime date = range.StartingTime.Value.Date;
            TimeSpan? earlier = null,later=null;
            if (range.StartingTime.Value.TimeOfDay > shiftDetails.openTime)
            {
                earlier = GetFirstAvailableTurn(shiftDetails, new TimeRange { StartingTime = date + shiftDetails.openTime, EndTime = range.StartingTime }, true);
                    
                    
            }
            if(range.EndTime.Value.TimeOfDay < shiftDetails.ClosedTime)
            {
                later = GetFirstAvailableTurn(shiftDetails, new TimeRange { StartingTime =range.EndTime , EndTime = date + shiftDetails.ClosedTime });

            }
            if (earlier  == null&&later==null)
                return null;
            if (earlier == null || later == null)
                return earlier == null ? date+later : date+earlier;

                return (range.StartingTime.Value.TimeOfDay-earlier).Value.TotalMinutes< 
                (later - range.EndTime.Value.TimeOfDay).Value.TotalMinutes?
                date + earlier : date + later;

        }




    }
}
