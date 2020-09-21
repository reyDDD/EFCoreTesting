using EFCoreTesting.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages
{
    public class Repeat2109 : ComponentBase
    {

        //первый способ реализовать зависимость от зависимости
        //[Inject]
        //public Context connect { get; set; }
        //[Inject]
        //public One2Many one2Many { get; set; }

        //public IEnumerable<Address> ReturnList()
        //{
        //   return one2Many.GetAddressWithFilter1();
        //}

    }
}
