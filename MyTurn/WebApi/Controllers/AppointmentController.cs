using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        [Route("Get/{appointmentId}"),HttpGet]
        public IHttpActionResult Get(int appointmentId)
        {
            return Ok( Bl.ApointmentBl.DeleteAppointment(appointmentId));
        }
    }
}
