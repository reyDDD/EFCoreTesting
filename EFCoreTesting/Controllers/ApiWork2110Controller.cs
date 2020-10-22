using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiWork2110Controller : ControllerBase
    {
        private IList<string> list = new List<string>();

        /// <summary>
        /// Добавление нового адреса в базу
        /// </summary>
        /// <remarks>
        /// пример содержимого запроса: 
        /// 
        /// {
        ///   "city": "большой город",
        ///   "country": "хорошая страна"
        /// }
        /// </remarks>
        /// <param name="user"></param>
        /// <returns>название добавленного города + гонево</returns>
        /// <response code="201">Возрат вновь созданного элемента</response>
        /// <response code="400">Если значение добавляемого элемента равно null</response>
        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult AddName(Address user)
        {

            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                list.Add(user.City);
                return CreatedAtRoute("MyId2", new { val = user.City }, user.City + " гонево");
            }
        }



        //[HttpGet("{val}", Name = "MyId")]
        //public ActionResult<string> Ind(string val)
        //{
        //    return Content("небольшая приставка " + val);
        //}


        [HttpGet("{val}", Name = "MyId2")]
        public ActionResult<string> Ind22(string val)
        {
            return Content("небольшая приставка222222222 " + val);
        }

        //public IActionResult Ind()
        //{
        //    return new JsonResult("забирай свой ответ");
        //}


        //[HttpGet("{id}")]
        //public IActionResult Ind2(int id)
        //{
        //    return Ok("забирай свой ответ");
        //}
    }
}
