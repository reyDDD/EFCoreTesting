using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure
{
    public class Work1611Attribute : Attribute, IRouteTemplateProvider
    {
        
        public string Name => "Work1611Case";

        public int? Order => 2;

        public string Template => "tudaSuda/[controller]/[action]";
 
    }
}
