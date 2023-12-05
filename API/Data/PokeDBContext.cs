using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Domain;
using Data.Helpers;


namespace Data
{
	public class PokeDBContext : DbContext
	{
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonType> PokemonTypes { get; set; }
        public DbSet<PokemonMove> PokemonMoves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<BattleMove> BattleMoves { get; set; }

        public PokeDBContext() { }

        public PokeDBContext(DbContextOptions<PokeDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConnectionString);

        }
    }
}

