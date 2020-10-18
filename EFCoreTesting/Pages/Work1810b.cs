using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages
{
    public partial class Work1810b
    {
        [Inject]
        public Work1810Service Servicee { get; set; }
        public Address Dependas { get; set; }

   
        public void GetDependency()
        {
            Dependas = Servicee.ReturAddressFirst();
        }

    }
}
