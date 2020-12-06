﻿using Bl.BLModels;
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
    public class CalcRouteController : ApiController
    {
        /// <summary>
        /// get from client new route details and send it to logic classes.
        /// </summary>
        
        public IHttpActionResult Post(Bl.RouteDto route)
        {
            try
            {
                Bl.Route r = Bl.Converters.RouteConverter.ToRoute(route);
                TurnResult res = Bl.Calcs.CalcRoute.Calc(r);
                Bl.BLModels.RouteBL.SaveRouteToDB(route,res);
                return Ok(res);
            }
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
         
          
           
        }
    }
}