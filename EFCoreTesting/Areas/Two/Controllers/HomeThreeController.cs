using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EFCoreTesting.Areas.Two.Controllers
{
    [Area("Two")]
    public class HomeThreeController : Controller
    {
        private readonly IOptions<Uzver> options;
        private ILogger<HomeThreeController> logger;

        public HomeThreeController(IOptions<Uzver> options, ILogger<HomeThreeController> logger)
        {
            this.options = options;
            this.logger = logger;
            try
            {
                var configValue = options.Value;
            }
            catch (OptionsValidationException ex)
            {
                foreach (var failure in ex.Failures)
                {
                    logger.LogError(failure);
                }
            }

        }
        public IActionResult Index()
        {
            try
            {
                string message = new StringBuilder().Append(options.Value.User + " " + options.Value.Age).ToString();
                return View("Index", message);
            }
            catch (OptionsValidationException ex)
            {
                return View("Index", ex.Message);
            }

        }
    }
}
