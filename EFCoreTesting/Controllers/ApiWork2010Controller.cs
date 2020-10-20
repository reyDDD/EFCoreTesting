using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiWork2010Controller : ControllerBase
    {

        public Context connect;
        public ApiWork2010Controller(Context connect)
        {
            this.connect = connect;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Userec>> ReurnUser(long id)
        {
            var user = await connect.Users.FindAsync(id);
            var userec = new Userec { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName };
            return userec;
        }

        public class Userec
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        [HttpPost("{addressId}")]
        public async Task<ActionResult<User>> AddNewUser(int addressId, User user)
        {
            var addr = await connect.Addresses.FindAsync(addressId);
            user.AddressId = addressId;
            user.Address = addr;
            var reta = await connect.Users.AddAsync(user);
            await connect.SaveChangesAsync();
            return CreatedAtAction(nameof(ReurnUser), reta.Entity.Id, reta.Entity);
        }


        [HttpPut("{userId}")]
        public async Task<ActionResult<User>> UpdateUser(long userId, User user)
        {
            connect.Entry(user).State = EntityState.Modified;

            try
            {
                await connect.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (connect.Users.Find(userId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            User user = await connect.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            connect.Users.Remove(user);
            await connect.SaveChangesAsync();

            return user;
        }
    }
}
