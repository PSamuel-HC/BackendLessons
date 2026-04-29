using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord.Helpers
{
    internal class DataVault<T> where T : class, IEntity, new()
    {
        private List<T> itemsList { get; set; } = new List<T>();

        public void AddItem(T item)
        {
            Console.WriteLine($"Adding item with id: {item.Id}");
            itemsList.Add(item);
        }
    }
}
