using System;
using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
	public class BattleService : IBattleService
	{
        private readonly IBattleRepository _bservice;

        public BattleService(IBattleRepository bservice)
        {
            _bservice = bservice;
        }

        public int Add(Battle battle)
        {
            if (battle == null) return 0;
            return _bservice.Add(battle);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _bservice.Delete(id);

        }

        public Battle Get(int id)
        {
            if (id <= 0) return null;
            return _bservice.Get(id);
        }

        public bool Update(Battle enc)
        {
            throw new NotImplementedException();
        }
    }
}

