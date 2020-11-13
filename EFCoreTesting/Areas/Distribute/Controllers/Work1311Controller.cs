using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alachisoft.NCache.Common.Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCoreTesting.Areas.Distribute.Controllers
{
    [Area("Distribute")]
    public class Work1311Controller : Controller
    {
        private IConfiguration configuration;
        private ILogger<Work1311Controller> logger;

        public Work1311Controller(IConfiguration configuration, ILogger<Work1311Controller> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        
        public IActionResult Index()
        {
            string res;
            using (logger.BeginScope("start debug scoupe"))
            {
                logger.LogDebug("Read this on Saturday");
                res = configuration.GetValue<string>("первый");
            }
            return View("Index", res);
        }

        protected override void Dispose(bool disposing)
        {
            logger = null;
            base.Dispose(disposing);
        }
    }
}
