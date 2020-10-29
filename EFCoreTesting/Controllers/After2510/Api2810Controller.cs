using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]")]
    [ApiController]
    public class Api2810Controller : ControllerBase
    {
        private IWork2510ModelRepo2 repo;

        public Api2810Controller(IWork2510ModelRepo2 repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<string>> ReturnString()
        {
            return "znachatina";
        }

        [HttpGet("{znach:int}", Name = "ReturnErrorData")]
        public async Task<ActionResult<string>> ReturnStringWithParam(int znach)
        {
            await Task.FromResult(znach);
            return znach + ":int";
        }

        [HttpGet("tut")] //если указать [HttpGet("/tut")], маршрут api/[controller]/tut не отработает, но отработает /tut
        public async Task<ActionResult<string>> ReturnStringWithParamAndNotQuery(string znach)
        {
            await Task.FromResult(znach);
            return "tut " + znach;
        }

        [HttpGet("getuser/{id}")]
        public async Task<ActionResult<User>> AddUserAsync(long id)
        {
            var user = await repo.GetUser(id);
            return user; ;
        }



        /// <summary>
        /// Добавление нового пользователя в базу
        /// </summary>
        /// <param name="user"></param>
        /// <remarks>
        /// тАк может выглядеть тело запроса
        /// {
        ///"id": 0,
        ///"firstName": "string",
        ///"lastName": "string",
        ///"age": 0,
        ///"birthDay": "2020-10-29",
        ///"isMale": true,
        ///"addressId": 0,
        ///"address": {
        ///  "id": 0,
        ///  "country": "string",
        ///  "city": "string"
        /// }
        ///}
        /// </remarks>
        /// <returns>Итоги выполнения запроса</returns>
        /// <response code="201">Запись была добавлена</response>
        [Produces("application/json")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AddUserAsync(User user)
        {
            await repo.AddUserAsync(user);
            return CreatedAtAction("ReturnErrorData", user.Id, user);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<User>> DeleteUserAsync(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await repo.DeleteUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpPut("one/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<User>> UpdateUserAsync1(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            var res = await repo.UpdateUser1Async(id, user);
            if (!res)
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        [HttpGet("origin/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<OriginalUser>> GetOriginaluser(long id)
        {
            var user = await repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return new OriginalUser { Id = user.Id, LastName = user.LastName, FirstName = user.FirstName, Address = user.AddressId };
        }


        [HttpPost("origin")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<OriginalUser>> AddOriginalUser(OriginalUser originalUser)
        {
            User user = new User { FirstName = originalUser.FirstName, LastName = originalUser.LastName, AddressId = originalUser.Address };

            await repo.AddUserAsync(user);

            return CreatedAtAction(nameof(GetOriginaluser), new { id = user.Id }, user);
        }

        [HttpPut("origin/{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OriginalUser>> UpdateOriginalUser(long id, OriginalUser originalUser)
        {
            if (id != originalUser.Id)
            {
                return BadRequest();
            }
            User user = new User { FirstName = originalUser.FirstName, LastName = originalUser.LastName, AddressId = originalUser.Address };

            var res = await repo.UpdateUser1Async(id, user);
            if (!res)
            {
                return NotFound();
            }

            return NoContent();
        }

        public class OriginalUser
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Address { get; set; }
        }

        //[HttpPut("two/{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult<User>> UpdateUserAsync2(long id, User user)
        //{

        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var forUpdate = await repo.GetUser(id);

        //    await TryUpdateModelAsync(forUpdate, "", m => m.FirstName, m => m.LastName, m => m.Age);
        //    var res = await repo.UpdateUser1Async(id, forUpdate);
        //    if (!res)
        //    {
        //        return NotFound();
        //    }
        //    return new NoContentResult();
        //}


    }
}
