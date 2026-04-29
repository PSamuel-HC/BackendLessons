using Homework_GenericTypesAndConstraints.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_GenericTypesAndConstraints.Data
{
    internal class DataVault<T> where T : class, IEntity, new()
    {

        private List<T> vault = new List<T>();

        public void AddItem(T item)
        {
            Console.WriteLine($"Adding item with Id {item.Id} to the Vault");
            vault.Add(item);
        }

        public T? GetById(Guid id)
        {
            return vault.Find(item => item.Id == id);
        }

        public T CreateAndAdd()
        {
            AddItem(new T());
            return vault.Last();
        }

    }
}
