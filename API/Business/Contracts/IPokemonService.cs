using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Business.Contracts
{
	public interface IPokemonService
	{
        //Create
        int Add(Pokemon enc);
        //Read
        Pokemon Get(int id);
        //Update
        bool Update(Pokemon enc);
        //Delete
        bool Delete(int id);

        bool RelatePokeToType(int PokeID, int TypeID);
        bool RelatePokeWeToWeaknessType(int PokeID, int TypeID);

        bool RelatePokeToMove(int PokeID, int MoveID);


        List<Pokemon> GetAllPokemon();
    }
}

