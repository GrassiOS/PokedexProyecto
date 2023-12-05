using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String IMG {get; set;}
        public int HP { get; set; }
        public String Description { get; set; }
        public String Color { get; set; }

        public int speed { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }


        [ForeignKey("PokemonTypes")]
        public int? TypeId { get; set; }
        public PokemonType? Type { get; set; }

        [ForeignKey("PokemonTypes")]
        public int? WeaknessTypeId { get; set; }
        public PokemonType? WeaknessType { get; set; }

        public List<PokemonMove>? PokemonMoves { get; set; }

    }
}


