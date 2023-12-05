using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Helpers;
using System.Numerics;

namespace Data.Implementation
{
	public class PokemonTypeRepository : IPokemonTypeRepository
	{
        public int Add(PokemonType entity)
        {
            if (entity == null) return 0;

            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                ctx.PokemonTypes.Add(entity);
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
            PokemonType enc;
            bool deleted = false;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.PokemonTypes.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.PokemonTypes.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public PokemonType Get(int id)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            PokemonType enc;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.PokemonTypes.Where(x => x.Id == id).FirstOrDefault();
            }
            return enc;
        }

        public bool Update(PokemonType entity)
        {
            throw new NotImplementedException();
        }

        public List<PokemonType> GetAllTypes()
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
           
                List<PokemonType> pokemonTypeList = ctx.PokemonTypes.ToList();
                return pokemonTypeList;
            }
        }
    }
}

