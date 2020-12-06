using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    //[RoutePrefix("api/Token")]
    [EnableCors("*", "*", "*")]
    public class TokenController : ApiController
    {

       // [Route("Get/{mail}/{password}")]

       //[HttpGet]
        public IHttpActionResult Get(string email,string password)
        {
         
            try
            {
                var business = Bl.BusinessBl.LogIn(password, email);
                if (business != null)
                    return Ok(business);
                return BadRequest("the user is not connected");
            }
            catch (Exception e)
            {
                return InternalServerError(e);

            }


        }
    }
}
