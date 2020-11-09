using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Pokedex.Controllers
{
    public class PokedexController : Controller
    {
        private ILogger<PokedexController> logger;

        public IActionResult Index()
        {
            return View();
        }

        public PokedexController(ILogger<PokedexController> logger)
        {
            this.logger = logger;
            logger.LogInformation("A user has used the pokedex");
        }
    }
}
