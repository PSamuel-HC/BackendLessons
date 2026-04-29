using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkGenericTypes
{
    internal class DataValut<T> where T: class, IEntity, new()
    {

        private List<T> _items = new List<T>();

        public void AddItem(T entity) {
            Console.WriteLine($"Adding item to with id: {entity.Id}");
            _items.Add(entity);
        }

        public T CreateAndAdd()
        {
            T item = new T();
            AddItem(item);
            return item;
        }

        public T GetById(Guid id)
        {
            return _items.Find(item => item.Id == id);
        }
    }
}
