using System;
using System.Collections.Generic;
using System.Text;

using GenericTypesAndConstraints.Interfaces;

namespace GenericTypesAndConstraints.DataVault
{
    public class DataVault<T> where T : class, IEntity, new()
    {
        private readonly List<T> _items = new();

        public void AddItem(T item)
        {
            Console.WriteLine($"Added item with Id: {item.Id}");
            _items.Add(item);
        }

        public T? GetById(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public T CreateAndAdd()
        {
            T item = new T();
            AddItem(item);
            return item;
        }
    }
}
