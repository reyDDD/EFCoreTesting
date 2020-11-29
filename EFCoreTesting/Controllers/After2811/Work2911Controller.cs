﻿using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2811
{
    public record Person
    {
        public string LastName { get; }
        public string FirstName { get; }

        public Person(string first, string last) => (FirstName, LastName) = (first, last);
    }

    public record Person2
    {
        public string FromProperty { get; }

        public Person2(string first) => FromProperty = first;

        //переопределение базового метода PrintMembers для управления способом вывода элементов на печать
        protected virtual bool PrintMembers(StringBuilder stringBuilder)
        {
            stringBuilder.Append($"FromProperty такой проперти = {FromProperty}");
            return true;
        }
    }

    public sealed record Person4
    {
        public string FromProperty { get; }

        public Person4(string first) => FromProperty = first;

        //переопределение базового метода PrintMembers для управления способом вывода элементов на печать
        private bool PrintMembers(StringBuilder stringBuilder)
        {
            stringBuilder.Append($"FromProperty такой проперти = {FromProperty}");
            return true;
        }
    }

    public abstract record Person5
    {
        public string FromProperty { get; }

        public Person5(string first) => FromProperty = first;

        //переопределение базового метода PrintMembers для управления способом вывода элементов на печать
        protected virtual bool PrintMembers(StringBuilder stringBuilder)
        {
            stringBuilder.Append($"FromProperty такой проперти = {FromProperty}");
            return true;
        }
    }

    public record Person3(string FirstName, string LastName); // упрощенный вариант записи

    public class Work2911Controller : Controller
    {

        public IActionResult Work3()
        {
            Person3 person = new Person3("personas", "fantomas");
            return View("Index", person.ToString()); //переопределнный ToString возвращает Person3 { FirstName = personas, LastName = fantomas }
        }

        public IActionResult Work4()
        {
            Person3 person = new Person3("personas", "fantomas");
            var (one, two) = person;//деконструкция записи в свойства
            return View("Index", one);
        }

        public IActionResult Work5()
        {
            Person3 person = new Person3("personas", "fantomas");
            Person3 brather = person with { FirstName = "bratelnik" }; //создание копии с измененным свойством
            return View("Index", brather.FirstName);
        }

        public IActionResult Work6()
        {
            Person3 person = new Person3("personas", "fantomas");
            Person3 brather = person with { }; //создание точной копии записи (значения не копируются, поверхностно копируются ссылки на значения)
            return View("Index", brather.FirstName);
        }

        public IActionResult Work7()
        {
            Person2 person = new Person2("personas");
            return View("Index", person.ToString());
        }

        public IActionResult Work1()
        {
            User user = new User();
            bool tr = user is User; //шаблон проверки соответсвия типу
            bool tr2 = (tr is true and (4 > 3)) || (tr is not false); //шаблон в круглых скобках подчеркивает приоритет 
            bool tr3 = (user.Id is (not 5) or (6 and > 2));
            string tpe = tr2 == true ? "user is User" : "user is not User";
            return View("Index", $"{tpe}");
        }

        public IActionResult Work2()
        {
            Model2911 model = new Model2911() { InitProperty = "стартонул" };
            Model2911 model2 = new Model2911();
            return View("Index", model2.InitProperty);
        }

        public IActionResult Index()
        {
            User user = new() { FirstName = "FirstName" };
            var res1 = GetUser(new());
            return View("Index", $"{user.FirstName} {res1.LastName}");
        }

        public User GetUser(User user)
        {
            //....work
            return new() { LastName = "LastName" };
        }
    }
}
