using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
	public class User
	{
        public int Id { get; set; }

        public String? IMG { get; set; }

        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }

        public List<Pokemon>? PokemonCollection { get; set; }


        public int Ws { get; set; }
        public int Ls { get; set; }
    }
}

