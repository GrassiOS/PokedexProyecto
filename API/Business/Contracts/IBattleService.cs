using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business.Contracts
{
	public interface IBattleService
	{
        //Create
        int Add(Battle enc);
        //Read
        Battle Get(int id);
        //Update
        bool Update(Battle enc);
        //Delete
        bool Delete(int id);
    }
}

