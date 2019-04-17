using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongReqServ.Services.SongReq;

namespace SongReqServ.Controllers
{
  
    [ApiController]
    public class SongRequestController : ControllerBase
    {
        private readonly SongReqManager sm;
        public SongRequestController(SongReqManager _sm)
        {
            sm = _sm;
        }
        //[HttpGet("/update")]
        //public ActionResult Get()
        //{
        //    sm.
        //    return Ok();
        //}
    }
}