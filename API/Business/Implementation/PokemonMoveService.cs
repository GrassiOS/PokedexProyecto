using System;
using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
	public class PokemonMoveService : IPokemonMoveService
	{
        private readonly IPokemonMoveRepository _pmservice;

        public PokemonMoveService(IPokemonMoveRepository lrep)
        {
            _pmservice = lrep;
        }

        public int Add(PokemonMove league)
        {
            if (league == null) return 0;
            return _pmservice.Add(league);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _pmservice.Delete(id);

        }

        public PokemonMove Get(int id)
        {
            if (id <= 0) return null;
            return _pmservice.Get(id);
        }

        public bool RelateMoveToType(int MoveID, int TypeID)
        {
            if (MoveID <= 0) return false;
            if (TypeID <= 0) return false;
            return _pmservice.RelateMoveToType(MoveID, TypeID);
        }

        public bool Update(PokemonMove enc)
        {
            throw new NotImplementedException();
        }
    }
}

