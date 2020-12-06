using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        [EnableCors("*", "*", "*")]
        public IHttpActionResult Get(string email, string phoneNumber)
        {

            try
            {
                var user = Bl.UserBl.LogIn(phoneNumber, email);
                if (user != null)
                    return Ok(user);
                return BadRequest("the user is not connected");
            }
            catch (Exception e)
            {
                return InternalServerError(e);

            }


        }

        public IHttpActionResult Post(Dto.UserDto user)
        {
            try
            {
                int result = Bl.Dal.UserDal.CreateUser(user);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}

