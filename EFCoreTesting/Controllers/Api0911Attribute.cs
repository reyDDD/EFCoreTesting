using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers
{
    public class Api0911Attribute : Attribute, IRouteTemplateProvider
    {
        public string Name { get; set; }

        public int? Order => 2;

        public string Template => "pipi/[controller]";
    }
}
