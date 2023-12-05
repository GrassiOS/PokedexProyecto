using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
    public class Battle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public User? User1 { get; set; }
        public User? User2 { get; set; }

        public Pokemon? ActivePokemonTrainer1 { get; set; }
        public Pokemon? ActivePokemonTrainer2 { get; set; }

        public BattleStatus Status { get; set; }
    }

}

