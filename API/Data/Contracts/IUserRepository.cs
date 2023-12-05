using System;
using Domain;
namespace Data.Contracts
{
	public interface IUserRepository :IGenericRepository<User>
	{
		public User GetUserFromEmailandPassword(String email, String password);
		public bool RelateUserToPoke(int userID, int pokeID);
		public bool UnrelateUserFromPoke(int userID, int pokeID);
    }
}

