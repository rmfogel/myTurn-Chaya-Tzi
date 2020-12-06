using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    //[RoutePrefix("api/Branch")]
    [EnableCors("*", "*", "*")]
    public class BranchController : ApiController
    {
       
        //[Route("get/{idBusiness}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Dto.BranchDto> Branches = Bl.BranchBl.GetBranches(id);
                return Ok(Branches);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        
        //[Route("delete/{idBranch}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                 Bl.Dal.BranchDal.deleteBranch(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(List<Dto.BranchDto> branches)
        {
            try
            {
                int result = Bl.Dal.BranchDal.updateBranches(branches);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Post(Dto.BranchDto branch)
        {
            try
            {
                int result = Bl.Dal.BranchDal.CreateBranch(branch);
                return Ok(result);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



    }

    }
