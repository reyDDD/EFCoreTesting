using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work2110Controller : Controller
    {

        public IActionResult Index(int id)
        {
            return (id) switch
            {
                (0) => Ok("параметр указан не был"),
                (1) => Ok("параметр равен 1"),
                int ids when ids is 3 and < 5 => Ok("параметр равен больше трех"),
                int fignya when fignya is 6 or <= 7 => Ok("параметр равен 6 или меньше чем 7"),
                var fignya when fignya is not 8 => Ok("параметр не равен 8"),
                (_) => Ok("и ничего не присвоено - ни один вариант проверки не прошел")
            };
        }


        public IActionResult Index2(int id)
        {
            string? result = null;
            if (id is 0)
            {
                result = "параметр указан не был";
            }
            result ??= "и ничего не присвоено - ни один вариант проверки не прошел";
            return Ok(result);
        }

 
        public IActionResult Index3()
        {
            User user = new() { Age = 65}; //упрощенный способ создания экземпляра класса
            var result = Work(new()); //упрощенный способ передачи экземпляра класса в качестве параметра метода, когда метод знает, экземпляр какого типа создавать
            return Ok(result);
        }
        public IActionResult Index4()
        {
            My my = new(); //отрабатывает конструктор по умолчанию
            My my2 = new(77); //отрабатывает пользоательский конструктор
            return Ok(my2.MyProperty);
        }

        int Work(User user)
        {
            if (user.Age is 0) user.Age = 99;
            return user.Age;
        }
        int Myy(My my)
        {
            return my.MyProperty;
        }
        public class My
        {
            public int MyProperty { get; set; }
            public My()
            {
                MyProperty = 1;
            }
            public My(int zn)
            {
                MyProperty = zn;
            }
        }
    }
}
