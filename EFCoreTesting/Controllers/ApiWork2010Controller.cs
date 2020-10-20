using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
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

        private Context connect;
        public ApiWork2010Controller(Context connect)
        {
            this.connect = connect;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> ReurnUser(long id)
        {
            var user = await connect.Users.FindAsync(id);
            return user;
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
    }
}
