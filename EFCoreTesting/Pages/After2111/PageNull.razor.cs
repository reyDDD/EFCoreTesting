using EFCoreTesting.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages.After2111
{
    public partial class PageNull
    {
        //[Parameter]
        public string Data { get; set; }

        [Inject]
        Vozvrat2909 repo { get; set; }

        private async Task Work()
        {
            var res = await repo.GetAddress();
            Data = res.ToList().FirstOrDefault().City;
        }
    }
}
