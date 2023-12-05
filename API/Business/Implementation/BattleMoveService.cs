using System;
using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
	public class BattleMoveService : IBattleMoveService
	{
        private readonly IBattleMoveRepository _bttmoveservice;

        public BattleMoveService(IBattleMoveRepository bmrep)
        {
            _bttmoveservice = bmrep;
        }

        public int Add(BattleMove bmove)
        {
            if (bmove == null) return 0;
            return _bttmoveservice.Add(bmove);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _bttmoveservice.Delete(id);

        }

        public BattleMove Get(int id)
        {
            if (id <= 0) return null;
            return _bttmoveservice.Get(id);
        }

        public bool Update(BattleMove enc)
        {
            throw new NotImplementedException();
        }
    }
}

