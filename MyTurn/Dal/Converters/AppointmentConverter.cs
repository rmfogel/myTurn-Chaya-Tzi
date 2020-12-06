using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Converters
{
  public  class AppointmentConverter
    {
        public static Dal.Appointment ToDalAppointment(Dto.AppointmentDto appointmentDto)
        {
            Dal.Appointment appointment = new Appointment();
            appointment.id = appointmentDto.id;
            appointment.userId = appointmentDto.userId;
            appointment.hour = appointmentDto.hour;
            appointment.getServiceDate = appointmentDto.getServiceDate;
            appointment.DurationService = appointmentDto.DurationService;
            appointment.dayId = appointmentDto.dayId;
            return appointment;

        }     
        public static List<Dal.Appointment> ToDalAppointmentList(List< Dto.AppointmentDto> appointmentsDto)
        {
            List<Dal.Appointment> appointmentsDal = new List<Appointment>();

            foreach (var item in appointmentsDto)
            {
                appointmentsDal.Add(ToDalAppointment(item));
            }
            return appointmentsDal;

        }

        public static Dto.AppointmentDto ToDtoAppointment(Dal.Appointment appointment)
        {
            Dto.AppointmentDto appointmentDto = new Dto.AppointmentDto();
              appointmentDto.id=appointment.id;
             appointmentDto.userId= appointment.userId ;
             appointmentDto.hour= appointment.hour ;
            appointmentDto.getServiceDate= appointment.getServiceDate;
            appointmentDto.DurationService = appointment.DurationService;
            appointmentDto.dayId = appointment.dayId;
            return appointmentDto;

        }
        public static List<Dto.AppointmentDto> ToDtoAppointmentList(List<Dal.Appointment> appointments)
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
