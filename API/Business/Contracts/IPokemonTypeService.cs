using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business.Contracts
{
	public interface IPokemonTypeService
	{
        //Create
        int Add(PokemonType enc);
        //Read
        PokemonType Get(int id);
        //Update
        bool Update(PokemonType enc);
        //Delete
        bool Delete(int id);

        List<PokemonType> GetAllTypes();
    }
}

