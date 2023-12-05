using System;
using System.Numerics;
using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokeservice;

        public PokemonService(IPokemonRepository pservice)
        {
            _pokeservice = pservice;
        }

        public int Add(Pokemon battle)
        {
            if (battle == null) return 0;
            return _pokeservice.Add(battle);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _pokeservice.Delete(id);

        }

        public Pokemon Get(int id)
        {
            if (id <= 0) return null;
            return _pokeservice.Get(id);
        }

        public bool Update(Pokemon enc)
        {
            throw new NotImplementedException();
        }

        public bool RelatePokeWeToWeaknessType(int PokeID, int TypeID)
        {
            if (PokeID <= 0) return false;
            if (TypeID <= 0) return false;
            return _pokeservice.RelatePokeToWeaknessType(PokeID, TypeID);
        }

        public bool RelatePokeToType(int PokeID, int TypeID)
        {
            if (PokeID <= 0) return false;
            if (TypeID <= 0) return false;
            return _pokeservice.RelatePokeToType(PokeID, TypeID);
        }

        public bool RelatePokeToMove(int PokeID, int MoveID)
        {
            if (PokeID <= 0) return false;
            if (MoveID <= 0) return false;
            return _pokeservice.RelatePokeToMove(PokeID, MoveID);
        }

        public List<Pokemon> GetAllPokemon()
        {
            return _pokeservice.GetAllPokemon();
        }


    }
}

