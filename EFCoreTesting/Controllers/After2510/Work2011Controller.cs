using EFCoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Services;
using EFCoreTesting.Infrastructure.TypeWrite;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work2011Controller : Controller
    {
        public IActionResult TestUsing()
        {
            using var context = new Context(new DbContextOptionsBuilder<Context>().UseSqlServer("").Options);
            return Ok();
        }

        public IActionResult Str()
        {
            Struct2011 struct2011 = new Struct2011();
            struct2011.MyProperty = "12";
            var res = struct2011.Work(14);

            struct2011.Dispose();

            Struct2011 struct2012; //если в структуре объявить свойство, инициализировать без конструктора не выйдет
            struct2012.MyProperty = "dd";
            struct2012.no = 33;
            struct2012.Work(3);

            return Ok(res);
        }

        public IActionResult IndexEnd()
        {
            int[] mass = new int[] { 3, 5, 7 };
            return Ok(mass[^1]); //индекс, который отсчитывается с конца
        }

        public IActionResult IndexRange()
        {
            int[] mass = new int[] { 3, 5, 7 };
            return Ok((mass[0..1])[0]); //диапазон значений, 5 в диапазон не войдет
        }

        public IActionResult IndexOpen()
        {
            int[] mass = new int[] { 3, 5, 7 };
            return Ok((mass[0..])[2]); //диапазон значений, открыт с конца, также может быть открыт с начала
        }


        public IActionResult RangeParam()
        {
            Range rang = ..2;

            int[] mass = new int[] { 3, 5, 7 };
            return Ok((mass[rang])[1]); //диапазон значений, открыт с конца, также может быть открыт с начала
        }

        public IActionResult RangeSpan()
        {
            Range rang = ..2;

            Span<int> mass = new int[] { 3, 5, 7 };
            return Ok((mass[rang])[1]); //диапазон значений, открыт с конца, также может быть открыт с начала
        }

        public IActionResult SysIndex()
        {
            System.Index cc = ^3; 

            Span<int> mass = new int[] { 3, 5, 7 };
            return Ok(mass[cc]); //диапазон значений, открыт с конца, также может быть открыт с начала
        }

        public IActionResult AskDouble(string text)
        {
            return Ok(text ??= "vot tak"); //присвоить значение, если переменная равна null
        }

        public IActionResult Record()
        {
            WorkWithRecord work = new WorkWithRecord();
            return Ok(work.Worker()); //присвоить значение, если переменная равна null
        }

    }
}
