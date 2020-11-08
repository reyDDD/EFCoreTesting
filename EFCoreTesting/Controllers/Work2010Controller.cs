using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EFCoreTesting.Controllers
{

    public class YaPlakalKogdaSmotrel : Attribute, IRouteTemplateProvider
    {
        public string Name => "estTakoy";

        public int? Order => 2;

        public string Template => "otkudaOnVsyalsya";
    }

    [YaPlakalKogdaSmotrel]
    public class Work2010Controller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("privet/{name}")]
        //[Route("[action]/{name}")]
        [HttpGet("[controller]/[action]/{name}", Name ="izbrannoe")]
        public IActionResult IndexPoydet(string name)
        {
            return View("Index");
        }

        [HttpGet("yessa", Name = "neraka")] //если переопределял имя контроллера через наследование от IRouteTemplateProvider, то нужно прописывать имя метода, ибо базовый не работает
        public IActionResult IndexZashel(string? name)
        {
            return View("Index");
        }


        [HttpGet("yess", Name = "nerak")]
        public IActionResult IndexPoydet2(string name)
        {
            var fullname = typeof(Work2010Controller).FullName;
            var template = ControllerContext.ActionDescriptor.AttributeRouteInfo?.Template;
            var path = Request.Path.Value;

            //создание сылки - отосительной и абсолютной с помощью Url.Action()
            var url = Url.Action(action: "yessa", controller: "otkudaOnVsyalsya", new { name = "fdf" });
            var urlAbsolute = Url.Action(action: "yessa", controller: "otkudaOnVsyalsya", new { name = "fdf" }, protocol: Request.Scheme);

            //ЭТОТ СПОСОБ ПРЕДПОЧТИТЕЛЬНЕЙ И ВИДИТ ПРИМЕНЕННЫЕ СОГЛАШЕНИЯ
            //создание сылки - отосительной и абсолютной с помощью Url.Action()
            var urlRoute = Url.RouteUrl("neraka", new { name = "fdf" });
            var urlRouteAbsolute = Url.RouteUrl("neraka", new { name = "fdf" }, protocol: Request.Scheme);
            var urlRouteAbsoluteIndexPoydet = Url.RouteUrl("izbrannoe", new { name = "poluchai" }, protocol: Request.Scheme);




            return View("Index2", $"Path: {path} fullname: {fullname}  template:{template} <br/> url:{url} url:{urlAbsolute} --- urlRoute:{urlRoute} urlRouteAbsolute:{urlRouteAbsolute} ----     urlRouteAbsoluteIndexPoydet: {urlRouteAbsoluteIndexPoydet}" );
        }
    }
}
