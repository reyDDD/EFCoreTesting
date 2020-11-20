using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2011Controller : Controller
    {
        public IActionResult TestUsing()
        {
            using var context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer("").Options);
            return Ok();
        }
    }
}
