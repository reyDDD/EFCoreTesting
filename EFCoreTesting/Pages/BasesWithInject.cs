using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages
{
    public class BasesWithInject : ComponentBase
    {
        [Inject]
        public Context Connect { get; set; }

        [Inject]
        public WorkOne2Many OneToNamy { get; set; }


        public void Add(User user)
        {
            OneToNamy.AddOrUpdate(user);
        }


    }
}
