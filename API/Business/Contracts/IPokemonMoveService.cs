using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Business.Contracts
{
	public interface IPokemonMoveService
	{
        //Create
        int Add(PokemonMove enc);
        //Read
        PokemonMove Get(int id);
        //Update
        bool Update(PokemonMove enc);
        //Delete
        bool Delete(int id);

        bool RelateMoveToType(int pokeID, int typeID);
    }
}

