using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Pokedex.Controllers
{
    public class PokedexController : Controller
    {
        private IPokedex pokedex;

        private ILogger<PokedexController> logger;

        
        public IActionResult Index()
        {
            JsonPokedex current = new JsonPokedex();
            current.GeneratedAt = DateTime.Now;

            string PageCreated = Convert.ToString(current.GeneratedAt);
            ViewBag.Date = PageCreated;
            return View(pokedex.GetAll());
        }

        public IActionResult Details(int id)
        {
            Pokemon pokemon = this.pokedex.Get(id);


            if(pokemon != null)
            {
                return View(pokemon);
            }
            return NotFound();
        }

        public PokedexController(ILogger<PokedexController> logger, IPokedex pokedex)
        {
            
            this.pokedex = pokedex;
            this.logger = logger;
            logger.LogInformation("A user has used the pokedex");
        }
    }
}
