using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Helpers;
using System.Numerics;


namespace Data.Implementation
{
	public class BattleMoveRepository : IBattleMoveRepository
	{
        public int Add(BattleMove entity)
        {
            if (entity == null) return 0;

            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                ctx.BattleMoves.Add(entity);
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
            BattleMove enc;
            bool deleted = false;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.BattleMoves.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.BattleMoves.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public BattleMove Get(int id)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            BattleMove enc;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.BattleMoves.Where(x => x.Id == id).FirstOrDefault();
            }
            return enc;
        }

        public bool Update(BattleMove entity)
        {
            throw new NotImplementedException();
        }
    }
}

