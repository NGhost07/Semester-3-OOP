using System.Collections.Generic;
using Shops.Model;

namespace Shops.Database.Infrastructure
{
    public abstract class Repository<T>
        where T : class, IEntity
    {
        public Repository()
        {
            Items = new List<T>();
        }

        protected List<T> Items { get; private set; }

        public T Add(T entity)
        {
            Items.Add(entity);

            return entity;
        }

        public T Delete(int id)
        {
            foreach (T item in Items)
            {
                if (item.Id == id)
                {
                    Items.Remove(item);

                    return item;
                }
            }

            return null;
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
            foreach (T item in Items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public T Update(T entity)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Id == entity.Id)
                {
                    Items[i] = entity;

                    return Items[i];
                }
            }

            return null;
        }
    }
}