using System;
namespace Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        int Add(T entity);

        T Get(int id);

        bool Update(T entity);

        bool Delete(int id);

    }
}

