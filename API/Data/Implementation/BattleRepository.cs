using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Helpers;
using System.Numerics;


namespace Data.Implementation
{
	public class BattleRepository : IBattleRepository
	{
        public int Add(Battle entity)
        {
            if (entity == null) return 0;

            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                ctx.Battles.Add(entity);
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
            Battle enc;
            bool deleted = false;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.Battles.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.Battles.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public Battle Get(int id)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            Battle enc;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.Battles.Where(x => x.Id == id).FirstOrDefault();
            }
            return enc;
        }

        public bool Update(Battle entity)
        {
            throw new NotImplementedException();
        }
    }
}

