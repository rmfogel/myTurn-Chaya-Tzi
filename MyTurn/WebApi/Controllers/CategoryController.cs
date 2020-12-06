using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace WebApi.Controllers
{
    //  [RoutePrefix( "Api/Category")]
    [EnableCors("*", "*", "*")]
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                List<Dto.CategoryDto> categories = Bl.CategoryBl.GetCategories();
                return Ok( categories);
            }
            catch (Exception)
            {

                return BadRequest();
            }
           
        }
    }
}
