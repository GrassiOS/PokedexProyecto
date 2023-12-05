using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Data.Helpers;


namespace Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        public int Add(User entity)
        {
            if (entity == null) return 0;

            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                ctx.Users.Add(entity);
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
            User enc;
            bool deleted = false;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.Users.Where(x => x.Id == id).FirstOrDefault();
                if (enc != null)
                {
                    ctx.Users.Remove(enc);
                    ctx.SaveChanges();
                    deleted = true;
                }
            }
            return deleted;
        }

        public User Get(int id)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)//Nombre de servidor
                .Options;
            User enc;
            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                enc = ctx.Users.Include(u => u.PokemonCollection)
                    .Where(x => x.Id == id).FirstOrDefault();
            }
            return enc;
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetUserFromEmailandPassword(String email, String password)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
            .UseSqlServer(Constants.ConnectionString)
            .Options;

            User authenticatedUser = null;

            using (var context = new PokeDBContext(options: connectionOptions))
            {
                // Find the user by email
                var user = context.Users
                    .Include(u => u.PokemonCollection)
                        .ThenInclude(u => u.WeaknessType)
                    .Include(u => u.PokemonCollection)
                        .ThenInclude(u => u.Type)
                     .Include(u => u.PokemonCollection)
                        .ThenInclude(u => u.PokemonMoves)
                            .ThenInclude(u => u.Type)

                    .FirstOrDefault(u => u.Email == email);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        authenticatedUser = user;
                    }
                }
            }

            return authenticatedUser;
        }

        public bool RelateUserToPoke(int userID, int pokeID)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var user = ctx.Users.Include(p => p.PokemonCollection)
                                                  .FirstOrDefault(p => p.Id == userID);

                if (user == null)
                {
                    return false;
                }
                var pokemon = ctx.Pokemons.FirstOrDefault(t => t.Id == pokeID);

                if (pokemon == null)
                {
                    return false;
                }
                user.PokemonCollection.Add(pokemon);

                ctx.SaveChanges();

                return true;
            }
        }

        public bool UnrelateUserFromPoke(int userID, int pokeID)
        {
            var connectionOptions = new DbContextOptionsBuilder<PokeDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new PokeDBContext(options: connectionOptions))
            {
                var user = ctx.Users.Include(p => p.PokemonCollection)
                                     .FirstOrDefault(p => p.Id == userID);

                if (user == null)
                {
                    return false;
                }

                var pokemon = user.PokemonCollection.FirstOrDefault(p => p.Id == pokeID);

                if (pokemon == null)
                {
                    return false;
                }

                user.PokemonCollection.Remove(pokemon);

                ctx.SaveChanges();

                return true;
            }
        }

    }
}