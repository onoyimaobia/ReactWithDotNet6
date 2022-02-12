using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;

namespace Restore.API.Controllers
{
    public class BuggyController: BaseApiController
    {
        [HttpGet("not-found")]
        public IActionResult GetNotFound(){
            return NotFound();
        }
        [HttpGet("bad-request")]
        public IActionResult GetBadRequest(){
            return BadRequest(new ProblemDetails{Title= "this is a bad request"});
        }
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized(){
            return Unauthorized();
        }
        [HttpGet("validation-error")]
        public IActionResult GetValidationError(){
            ModelState.AddModelError("problem", "error occurred");
            ModelState.AddModelError("issue", "fields are required");
            return ValidationProblem();
        }
        [HttpGet("server-error")]
        public IActionResult GetServerError(){
            throw new Exception("server error");
        }
    }
}