using EFCoreTesting.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api2211Controller : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public IActionResult Add([FromBody]User user, [FromServices]Context context)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return CreatedAtAction("Index", new { userId = user.Id }, user);
        }

       // [EnableCors]
        [EnableCors("firsPolicyBlock")]
        [Produces("application/json")]
        [HttpGet("{userId}")]
        public IActionResult Index(long userId, [FromServices] Context context)
        {
            var user = context.Users.Include(c => c.Address).Where(x => x.Id == userId).FirstOrDefault();

            return Ok(user);
        }
    }
}
