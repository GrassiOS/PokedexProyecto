using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Helpers;
using System.Numerics;
using System;
using Newtonsoft.Json;


namespace Data.Implementation
{
	public class PokemonRepository : IPokemonRepository
    {
        public int Add(Pokemon entity)
        {
            if (entity == null) return 0;

            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                ctx.Pokemons.Add(entity);
                ctx.SaveChanges();
                return entity.Id;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                 .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                 .Options;
            Pokemon enc;
            bool deleted = false;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.Pokemons.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.Pokemons.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public Pokemon Get(int id)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var pokemon = ctx.Pokemons.Include(p => p.Type).Include(p => p.WeaknessType).Include(p => p.PokemonMoves)
                                          .FirstOrDefault(p => p.Id == id);
                return pokemon;
            }
        }


        public bool RelatePokeToType(int pokeID, int typeID)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var existingPokemon = ctx.Pokemons.Include(p => p.Type)
                                                  .FirstOrDefault(p => p.Id == pokeID);

                if (existingPokemon == null)
                {
                    return false;
                }
                var type = ctx.PokemonTypes.FirstOrDefault(t => t.Id == typeID);

                if (type == null)
                {
                    return false;
                }
                existingPokemon.Type = type;

                ctx.SaveChanges();

                return true;
            }
        }

        public bool RelatePokeToWeaknessType(int pokeID, int typeID)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var existingPokemon = ctx.Pokemons.Include(p => p.WeaknessType)
                                                  .FirstOrDefault(p => p.Id == pokeID);

                if (existingPokemon == null)
                {
                    return false;
                }
                var type = ctx.PokemonTypes.FirstOrDefault(t => t.Id == typeID);

                if (type == null)
                {
                    return false;
                }
                existingPokemon.WeaknessType = type;

                ctx.SaveChanges();

                return true;
            }
        }

        public bool RelatePokeToMove(int pokeID, int moveID)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var existingPokemon = ctx.Pokemons.Include(p => p.PokemonMoves)
                                                  .FirstOrDefault(p => p.Id == pokeID);

                if (existingPokemon == null)
                {
                    return false;
                }
                var move = ctx.PokemonMoves.FirstOrDefault(t => t.Id == moveID);

                if (move == null)
                {
                    return false;
                }
                existingPokemon.PokemonMoves.Add(move);

                ctx.SaveChanges();

                return true;
            }
        }





        public bool Update(Pokemon entity)
        {
            throw new NotImplementedException();
        }

        public List<Pokemon> GetAllPokemon()
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                List<Pokemon> pokemonList = ctx.Pokemons
                                                .Include(p => p.Type)
                                                .Include(p => p.WeaknessType)
                                                .Include(p => p.PokemonMoves).ThenInclude(m => m.Type)
                                                .ToList();


                //List<PokemonDTO> pokemonDTOList = new List<PokemonDTO>(); ;

                return pokemonList;
            }
        }
    }
}

