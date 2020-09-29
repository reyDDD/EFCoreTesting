using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages
{
    public class Inject2909 : ComponentBase
    {

        [Inject]
        public Work2809 Work2809 { get; set; }

        [Inject]
        public Context Context { get; set; }
    }
}
