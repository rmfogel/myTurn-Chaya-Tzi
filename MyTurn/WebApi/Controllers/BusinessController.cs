using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
 //  [RoutePrefix("api/Business")]
    [EnableCors("*","*","*")]
    public class BusinessController : ApiController
    {
        public IHttpActionResult Get(int id)
        {

            var business = Bl.Dal.BusinessDal.GetBusinessesByCategory(id);
            if (business != null)
                return Ok(business);
            return BadRequest();

        }


        //public IHttpActionResult Get(string token)
        //{
        //    int idUser = removeToken(token);
        //    var business = Bl.Dal.BusinessDal.GetBusiness(idUser);
        //    if (business != null)
        //        return Ok(business);
        //    return BadRequest("the user is not connected");

        //}

 

        public IHttpActionResult Post(Dto.BusinessDto business)
        {
            try
            {
                 return Ok(Bl.BusinessBl.AddBusiness(business));
            }
            catch (Exception e)
            {
                return InternalServerError(e);


            }
           

        }
        public IHttpActionResult Put(Dto.BusinessDto business)
        {
            try
            {
                return Ok(Bl.Dal.BusinessDal.UpdateBusiness(business));
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
           
           
                
        }


       
    }
}
