using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1211Controller : Controller
    {
        private Context context;
        public Work1211Controller(Context context)
        {
            this.context = context;
        }
        public IActionResult Index(long id, string name)
        {
            if (id <=0 || string.IsNullOrEmpty(name))
            {
                return BadRequest("Или айди не задан или он меньше равен нулю или имя для замены не указано");
            }
            var userec = context.Users.Find(id);
            if (userec == null)
            {
                return NotFound("не найден пользователь в базе с ИД " + id);
            }
            
            userec.LastName = name;
            context.SaveChanges();
            userec = context.Users.AsNoTracking().FirstOrDefault(x=> x.Id ==userec.Id);
            return View(userec);
        }
    }
}
