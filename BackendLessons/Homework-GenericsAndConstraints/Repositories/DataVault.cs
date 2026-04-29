using JalaUniversity.Homework_GenericsAndConstraints.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JalaUniversity.Homework_GenericsAndConstraints.Repositories
{
    internal class DataVault<T> where T: class, IEntity, new() 
    {
        /*These restrictions ensure that it is of reference type, implements "IEnity", and has a default constructor*/
        private List<T> myItems = new List<T>();

        internal void AddItem(T item)
        {
            myItems.Add(item);
            Console.WriteLine("Item ID: "+item.Id);
        }

        internal T? GetById(Guid id)
        {
            return myItems.FirstOrDefault(x => x.Id == id);
        }

        internal T CreateAndAdd()
        {
            T item = new T();
            AddItem(item);
            return item;
        }
    }
}
