using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	public class PokemonDTO
	{
        public int Id { get; set; }
        public String Name { get; set; }
        public String IMG { get; set; }
        public int HP { get; set; }
        public String Description { get; set; }
        public String Color { get; set; }

        public int speed { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }


        public int? TypeId { get; set; }
        public String? Type { get; set; }


        public int? WeaknessTypeId { get; set; }
        public String? WeaknessType { get; set; }

        public List<String>? PokemonMoves { get; set; }

        public List<String>? Users { get; set; }


        //DTO
        public PokemonDTO(Pokemon pokemon)
        {
            Id = pokemon.Id;
            Name = pokemon.Name;
            IMG = pokemon.IMG;
            HP = pokemon.HP;
            Description = pokemon.Description;
            Color = pokemon.Color;
            speed = pokemon.speed;
            attack = pokemon.attack;
            defense = pokemon.defense;
            TypeId = pokemon.TypeId;
            Type = pokemon.Type != null ? pokemon.Type.Name : null;
            WeaknessTypeId = pokemon.WeaknessTypeId;
            WeaknessType = pokemon.WeaknessType != null ? pokemon.WeaknessType.Name : null;
            PokemonMoves = pokemon.PokemonMoves != null ? pokemon.PokemonMoves.Select(move => move.Name).ToList() : null;
        }

    }
}

