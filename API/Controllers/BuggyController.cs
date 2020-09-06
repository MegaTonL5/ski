﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notFound")]
        public ActionResult GetNoFoundRequest()
        {
            var thing = _context.Products.Find(1001);
            if(thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]

        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(1001);
            var thingToReturn = thing.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]

        public ActionResult GetBadRequest()
        {

            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]

        public ActionResult GetNoFoundRequest(int id)
        {

            return Ok();
        }


    }
}