using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace EFCoreTesting.Controllers.After2510
{
    public class Work0311Controller : Controller
    {
        public IActionResult Index(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return View("Index", "zero");
            }
            var encoder = HtmlEncoder.Create(UnicodeRanges.All);
            var encode = encoder.Encode(data);
            return View("Index", encode);
        }
    }



}
