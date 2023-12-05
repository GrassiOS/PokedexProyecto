using System;
using Domain;
namespace Data.Contracts
{
	public interface IPokemonTypeRepository : IGenericRepository<PokemonType>
	{
        public List<PokemonType> GetAllTypes();
    }
}

