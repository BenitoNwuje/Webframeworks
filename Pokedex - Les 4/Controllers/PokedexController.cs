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
        private ILogger<PokedexController> logger;

        private List<Pokemon> getPokemon()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var lines = System.IO.File.ReadAllText(@"pokedex.json");
            return JsonSerializer.Deserialize<List<Pokemon>>(lines, options);
        }

        public IActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
            string PageCreated = Convert.ToString(currentDate);

            ViewBag.Date = PageCreated;

            return View(getPokemon());
        }

        public IActionResult Details(int id)
        {
            foreach(var pokemon in getPokemon())
            {
                if (pokemon.Id == id)
                {
                    return View(pokemon);
                }
            }
            return NotFound();
        }

        public PokedexController(ILogger<PokedexController> logger)
        {
            this.logger = logger;
            logger.LogInformation("A user has used the pokedex");
        }
    }
}
