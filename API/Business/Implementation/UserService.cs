using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository preguntaRepo)
        {
            _userRepo = preguntaRepo;
        }

        public int Add(User enc)
        {
            if (enc == null) return 0;
            return _userRepo.Add(enc);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _userRepo.Delete(id);

        }

        public User Get(int id)
        {
            if (id <= 0) return null;
            return _userRepo.Get(id);
        }

        public bool Update(User enc)
        {
            throw new NotImplementedException();
        }

        public User GetUserFromEmailandPassword(String email, String password)
        {
            if (email == null) return null;
            if (password == null) return null;
            return _userRepo.GetUserFromEmailandPassword(email,password);
        }

        public bool RelateUserToPoke(int userID, int pokeID)
        {
            if (userID == null) return false;
            if (pokeID == null) return false;
            return _userRepo.RelateUserToPoke(userID, pokeID);
        }

        public bool UnrelateUserFromPoke(int userID, int pokeID)
        {
            if (userID == null) return false;
            if (pokeID == null) return false;
            return _userRepo.UnrelateUserFromPoke(userID, pokeID);
        }
    }
}

