using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.Dal;
using Dto;

namespace Bl.Converters
{
  public  class AppointmentConverter
    {
        public static Appointment ToDalAppointment(Dto.AppointmentDto appointmentDto)
        {
            Appointment appointment = new Appointment();
            appointment.id = appointmentDto.id;
            appointment.userId = appointmentDto.userId;
            appointment.dateTimeTurn = appointmentDto.hour;
            appointment.getServiceDate = appointmentDto.hour;
            appointment.DurationService = appointmentDto.DurationService;
            appointment.BranchDayId = appointmentDto.Day.id;
            return appointment;

        }     
        public static List<Appointment> ToDalAppointmentList(List< Dto.AppointmentDto> appointmentsDto)
        {
            List<Appointment> appointmentsDal = new List<Appointment>();

            foreach (var item in appointmentsDto)
            {
                appointmentsDal.Add(ToDalAppointment(item));
            }
            return appointmentsDal;

        }

        public static Dto.AppointmentDto ToDtoAppointment(Appointment appointment)
        {
            Dto.AppointmentDto appointmentDto = new Dto.AppointmentDto();
           appointmentDto.id=appointment.id;
           appointmentDto.userId= appointment.userId;
           appointmentDto.hour= appointment.dateTimeTurn ;
           appointmentDto.DurationService = appointment.DurationService.Value;
           appointmentDto.Day =Converters.ShiftDetailConverter.ToDtoShiftDetail(appointment.ShiftDayDetail);

            appointmentDto.Bussiness= Converters.BusinessConverter.ToDtoBusiness(appointment.ShiftDayDetail.Shift.Branch.Business);
            appointmentDto.Service = Converters.ServiceConverter.ToDtoService(appointment.ShiftDayDetail.Shift.Service);
            //todo:צירוף היום והשעה משני אוביקטים


            appointmentDto.hour = appointment.dateTimeTurn;
            //new DateTime(year, month, day1, optionalShift.AvilableTime.Hours, optionalShift.AvilableTime.Minutes, optionalShift.AvilableTime.Seconds); 
            appointmentDto.Address = new PointOnMap(appointment.ShiftDayDetail.Shift.Branch.adress);
            appointmentDto.Day = Converters.ShiftDetailConverter.ToDtoShiftDetail(appointment.ShiftDayDetail);

            return appointmentDto;

        }
        public static List<Dto.AppointmentDto> ToDtoAppointmentList(List<Appointment> appointments)
        {
            List<Dto.AppointmentDto> appointmentsDto = new List<Dto.AppointmentDto>();

            foreach (var item in appointments)
            {
                appointmentsDto.Add(ToDtoAppointment(item));
            }
            return appointmentsDto;

        }
    }
}
