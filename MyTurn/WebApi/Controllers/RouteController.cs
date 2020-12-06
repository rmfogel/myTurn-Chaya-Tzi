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

    public class RouteController : ApiController
    {
        public IHttpActionResult Get(int userId)
        {
            return Ok(Bl.BLModels.RouteBL.GetUsersRoutes(userId));
        }
    }
}
