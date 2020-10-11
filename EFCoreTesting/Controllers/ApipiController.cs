using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApipiController : ControllerBase
    {
        // GET: api/<ApipiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ApipiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value + {id}";
        }

        // POST api/<ApipiController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] Testoviy value)
        {
            return  value.Text + " addons";
        }

        public class Testoviy
        {
            public string Text { get; set; }

        }


        // PUT api/<ApipiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApipiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
