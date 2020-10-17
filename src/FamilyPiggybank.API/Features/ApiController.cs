using FamilyPiggybank.API.Infrastructure.Envelope;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace FamilyPiggybank.API.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Created()
        {
            return new StatusCodeResult(StatusCodes.Status201Created);
        }

        protected IActionResult Forbidden()
        {
            return base.Forbid();
        }

        protected IActionResult Conflict(ICollection<Error> errors = null)
        {
            return base.Conflict(Envelope.Error(errors));
        }

        protected IActionResult BadRequest(ICollection<Error> errors = null)
        {
            return base.BadRequest(Envelope.Error(errors));
        }

        protected IActionResult InternalError()
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
