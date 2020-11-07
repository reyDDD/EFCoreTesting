﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Controllers.After2510
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Api0711Controller : ControllerBase
    {
        private Context context;

        public Api0711Controller(Context context)
        {
            this.context = context;
        }

        [HttpGet(Name = "vanechka")]
        public ActionResult<Address> GetAddress(long id)
        {
            var address = context.Addresses.Include(i => i.Users).Where(i => i.Id == id).FirstOrDefault();
            address.Users = null;
            return address;
        }



        [HttpPost("xx2")]
        public string AddAddress33()
        {

            return ";;";
        }



        [HttpPost("xx")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> AddAddress( Address address)
        {
            context.Addresses.Add(address);
            await context.SaveChangesAsync();
            return CreatedAtRoute("vanechka", address.Id, address);
        }


        [HttpGet]
        public ActionResult<User> Getid(long id)
        {
            return context.Users.Include(i => i.Address).Where(i => i.Id == id).FirstOrDefault();
        }

        //при выборе одного из двух маршрутов ниже выбирает тот, что {id:int}
        [HttpGet("tut/{id}")]
        public IActionResult GetId(int id)
        {
            return Ok("[HttpGet('tut/{id}')] " + id);
        }

        [HttpGet("tut/{id:int}")]
        public IActionResult GetId2(int id)
        {
            return Ok("[HttpGet('tut222/{id}')] " + id);
        }
    }
}
