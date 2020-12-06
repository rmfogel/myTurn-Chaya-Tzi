using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class AppointmentDto
    {
        public int id { get; set; }
       
        public DateTime? hour { get; set; }
        public int? userId { get; set; }
        public ServiceDto Service { get; set; }
        public PointOnMap Address { get; set; }

        public BusinessDto Bussiness { get; set; }
        public Dto.ShiftDayDetailsDto Day { get; set; }
        public int DurationService { get; set; }



    }
}
