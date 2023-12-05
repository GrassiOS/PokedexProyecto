using System;
using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
	public class PokemonTypeService : IPokemonTypeService 
	{
        private readonly IPokemonTypeRepository _ptservice;

        public PokemonTypeService(IPokemonTypeRepository lrep)
        {
            _ptservice = lrep;
        }

        public int Add(PokemonType league)
        {
            if (league == null) return 0;
            return _ptservice.Add(league);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _ptservice.Delete(id);

        }

        public PokemonType Get(int id)
        {
            if (id <= 0) return null;
            return _ptservice.Get(id);
        }

        public bool Update(PokemonType enc)
        {
            throw new NotImplementedException();
        }

        public List<PokemonType> GetAllTypes()
        {
            return _ptservice.GetAllTypes();
        }
    }
}

