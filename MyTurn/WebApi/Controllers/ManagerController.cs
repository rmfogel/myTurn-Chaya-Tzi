using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    public class ManagerController : ApiController
    {
        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get(int id)
        {

            var business = Bl.BusinessBl.GetBusiness(id);
            if (business != null)
                return Ok(business);
            return BadRequest("the business is not connected");

        }
    }
}
