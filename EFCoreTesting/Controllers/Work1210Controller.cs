﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTesting.Controllers
{
    public class Work1210Controller : Controller
    {
        public IActionResult Index()
        {
            var cc = new TextEncoderSettings();
            cc.AllowCharacters('<', '>'); //пропуск кодирования этих символов запрещен по умолчанию

            var res = HtmlEncoder.Create(UnicodeRanges.All);
             //res = HtmlEncoder.Create(cc); 
    
            var resu = res.Encode($"<b>некодированный текст с разметкой vot takaya ona</b>");
            return View("Index", resu);
        }
    }
}
