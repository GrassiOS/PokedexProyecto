using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain
{
    public class PokemonType
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String IMG { get; set; }


    }
}

