using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public interface IPokedex
    {
        public DateTime GeneratedAt { get; set; }
        Pokemon Get(int id);
        List<Pokemon> GetAll();
        void Save(Pokemon pokemon);

    }
}
