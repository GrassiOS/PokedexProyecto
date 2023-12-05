using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business.Contracts
{
	public interface IUserService
	{
        //Create
        int Add(User enc);
        //Read
        User Get(int id);
        //Update
        bool Update(User enc);
        //Delete
        bool Delete(int id);

        User GetUserFromEmailandPassword(String email, String password);
        bool RelateUserToPoke(int userID, int pokeID);

        bool UnrelateUserFromPoke(int userID, int pokeID);
    }
}

