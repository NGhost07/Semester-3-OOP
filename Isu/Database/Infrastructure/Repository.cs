using System.Collections.Generic;
using System.Linq;
using Isu.Model;

namespace Isu.Database.Infrastructure
{
    public abstract class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected Repository()
        {
            Items = new List<T>();
        }

        protected IList<T> Items { get; private set; }

        public T Add(T entity)
        {
            Items.Add(entity);

            return entity;
        }

        public T Delete(int id)
        {
            var items = Items.Where(item => item.Id == id).Select(item => item);

            return (items.Count() == 0) ? null : items.First();
        }

        public T Delete(T entity)
        {
            Items.Remove(entity);

            return entity;
        }

        public IList<T> GetAll()
        {
            return Items;
        }

        public T GetById(int id)
        {
            var items = Items.Where(item => item.Id == id).Select(item => item);

            return (items.Count() == 0) ? null : items.First();
        }

        public T Update(T entity)
        {
            if (entity == null)
                return null;

            int index = Items.IndexOf(entity);
            Items.RemoveAt(index);
            Items.Insert(index, entity);

            return entity;
        }
    }
}