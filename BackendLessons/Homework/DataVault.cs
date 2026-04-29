using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace JalaUniversity.BackendLessons
{
    public class DataVault<T> where T : class, IEntity, new()

    {
        private List<T> _items = new List<T>();
        public void AddItem(T item)
        {
            Console.WriteLine($"Adding item with ID: {item.Id}");
            _items.Add(item);
        }

        public T? GetById(Guid id)
        {
            return _items.FirstOrDefault(item => item.Id == id);
        }

        public T CreateAndAdd()
        {
            T newItem = new T();
            AddItem(newItem);
            return newItem;
        }
    }
}
