using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApiWork1910Controller : ControllerBase
    {
        private Vozvrat2909 vozvrat2909;

        public ApiWork1910Controller(Vozvrat2909 vozvrat2909)
        {
            this.vozvrat2909 = vozvrat2909;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NewAddress>> AddAddress(Address address)
        {
            var res = await vozvrat2909.AddAddress(address);

            List<NewUser> newUser = new List<NewUser>();

            if (res.Users?.Count() > 0)
            {
                foreach (var user in res.Users)
                {
                    newUser.Add(new NewUser
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Age = user.Age,
                        BirthDay = user.BirthDay,
                        IsMale = user.IsMale
                    });
                }
            }

            NewAddress newAddress = new NewAddress()
            {
                Id = res.Id,
                City = res.City,
                Country = res.Country,
                Users = newUser
            };

            return CreatedAtAction(nameof(ReturnAddress), newAddress.Id, newAddress);
        }

        public class NewAddress
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public IEnumerable<NewUser> Users { get; set; }
        }
        public class NewUser
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public DateTime BirthDay { get; set; }
            public bool IsMale { get; set; }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<NewAddress>> ReturnAddress(int id)
        {
            var res = vozvrat2909.GetAddressId(id);
            if (res == null)
            {
                return NotFound();
            }
            List<NewUser> newUser = new List<NewUser>();
            foreach (var user in res.Users)
            {
                newUser.Add(new NewUser
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    BirthDay = user.BirthDay,
                    IsMale = user.IsMale
                });
            }
            NewAddress newAddress = new NewAddress()
            {
                Id = res.Id,
                City = res.City,
                Country = res.Country,
                Users = newUser
            };

            return newAddress;
        }


        [HttpPut("{ids}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAddress(int ids, Address address)
        {
            if (ids != address.Id)
            {
                return BadRequest();
            }
            await Task.Run(() => vozvrat2909.UpdateAddress(address));

            return NoContent();
        }
    }
}
