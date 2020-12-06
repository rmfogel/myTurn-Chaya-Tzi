using Dto;
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

    public class ServiceOfBusinessController : ApiController
    {
        public IHttpActionResult Get(int id,int branchId)
        {
            List<ServiceDto> services;
            if (branchId==0)
           services  = Bl.Dal.ServiceDal.GetServices(id);
            else services= Bl.Dal.ServiceDal.GetServicesForBranch(branchId);
            if (services != null)
                return Ok(services);
            return BadRequest();

        }

    }
}
