using System;
using Domain;
namespace Data.Contracts
{
	public interface IPokemonMoveRepository : IGenericRepository<PokemonMove>
	{
        public bool RelateMoveToType(int pokeID, int typeID);
    }
}

