using homework_05.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace homework_05.Models
{
    // TASK 2
    // T Generic
    internal class DataVault<T> where T : class, IEntity, new()
    {
        // Private List
        private List<T> _list;

        public DataVault()
        {
            _list = [];
        }

        // Add Fuction
        public void AddItem(T element)
        {
            Console.WriteLine($"Saved Item\nID: {element.Id}\n");
            _list.Add(element);
        }

        // Get Function TODO: I have a question here about managing of null
        public T GetById(int id)
        {
            T element = (_list).FirstOrDefault(item => item.Id == id);
            return element;
        }

        // Create And Add Function
        public T CreateAndAdd()
        {
            T newElement = new T();
            _list.Add(newElement);
            return newElement;
        }
    }
}
