using System.Collections.Generic;

namespace Isu.Database.Infrastructure
{
    public interface IRepository<T>
        where T : class
    {
        T Add(T entity);
        T Update(T entity);

        T Delete(int id);
        T Delete(T entity);

        T GetById(int id);
        List<T> GetAll();
    }
}