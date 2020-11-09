using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class JsonPokedex : IPokedex
    {
        private List<Pokemon> pokemons;

        public DateTime GeneratedAt { get ; set; }

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

        public JsonPokedex()
        {
            this.pokemons = getPokemon();
            this.GeneratedAt = DateTime.Now;
        }

        public Pokemon Get(int id)
        {
            foreach (var pokemon in pokemons)
            {
                if (pokemon.Id == id)
                {
                    return pokemon;
                }
            }
            return null;
        }

        public List<Pokemon> GetAll()
        {
            return pokemons.ToList();
        }

        public void Save(Pokemon pokemon)
        {
            //geeft terug het index als pokemons.id gelijk is aan pokemon.id
            var index = this.pokemons.FindIndex(p => p.Id == pokemon.Id);

            //hier vervangen wij het oude pokemon met het nieuwe pokemon
            this.pokemons[index] = pokemon;

        }
    }
}
