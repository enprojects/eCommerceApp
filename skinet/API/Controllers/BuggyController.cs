
using API.Data;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretText()
        {
            return "secret stuff";
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            //var thing = _context.Products.Find(42);

            //if (thing == null)
            //{

            //    return StatusCode((int)HttpStatusCode.NotFound);
            //}            
            return StatusCode((int)HttpStatusCode.NotFound);
            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            //var thing = _context.Products.Find(42);

            //var thingToReturn = thing.ToString();

             throw new  NotImplementedException();

            return Ok();
        }

       

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}