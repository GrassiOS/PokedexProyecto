using System;
using Domain;
namespace Data.Contracts
{
	public interface IPokemonRepository : IGenericRepository<Pokemon>
	{
		public bool RelatePokeToType(int pokeID, int typeID);
        public bool RelatePokeToWeaknessType(int pokeID, int typeID);

        public bool RelatePokeToMove(int PokeID, int MoveID);

        public List<Pokemon> GetAllPokemon();
	}
}

