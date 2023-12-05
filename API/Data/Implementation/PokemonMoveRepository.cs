using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Helpers;
using System.Numerics;

namespace Data.Implementation
{
	public class PokemonMoveRepository: IPokemonMoveRepository
	{
        public int Add(PokemonMove entity)
        {
            if (entity == null) return 0;

            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                ctx.PokemonMoves.Add(entity);
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
            PokemonMove enc;
            bool deleted = false;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.PokemonMoves.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.PokemonMoves.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public PokemonMove Get(int id)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            PokemonMove enc;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.PokemonMoves.Where(x => x.Id == id).Include(m => m.Type).FirstOrDefault();
            }
            return enc;
        }

        public bool Update(PokemonMove entity)
        {
            throw new NotImplementedException();
        }

        public bool RelateMoveToType(int moveID, int typeID)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var existingmove = ctx.PokemonMoves.Include(p => p.Type)
                                                  .FirstOrDefault(p => p.Id == moveID);

                if (existingmove == null)
                {
                    return false;
                }
                var type = ctx.PokemonTypes.FirstOrDefault(t => t.Id == typeID);

                if (type == null)
                {
                    return false;
                }
                existingmove.Type = type;

                ctx.SaveChanges();

                return true;
            }
        }
    }
}

