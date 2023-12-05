using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	public class PokemonMove
	{

        public int Id { get; set; }
        public String Name { get; set; }
        public int Power { get; set; }
        public int Accuracy { get; set; }

        [ForeignKey("PokemonTypes")]
        public PokemonType? Type { get; set; }

    }
}

