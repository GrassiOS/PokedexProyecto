using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business.Contracts
{
	public interface IBattleMoveService
	{
        //Create
        int Add(BattleMove enc);
        //Read
        BattleMove Get(int id);
        //Update
        bool Update(BattleMove enc);
        //Delete
        bool Delete(int id);
    }
}

