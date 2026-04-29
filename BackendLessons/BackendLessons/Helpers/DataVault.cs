using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord.Helpers
{
    internal class DataVault<TItem> where TItem : class, IEntity, new()
    {
        private List<TItem> ItemsList { get; set; } = new List<TItem>();

        public void AddItem(TItem item)
        {
            Console.WriteLine($"Adding item with id: {item.Id}");
            ItemsList.Add(item);
        }

        public TItem? GetById(Guid id)
        {
            if (ItemsList.Count == 0)
            {
                return null;
            }

            TItem? returnedItem = ItemsList.Find(item => item.Id == id) ?? null;

            return returnedItem;

        }

        public TItem CreateAndAdd()
        {
            TItem newElement = new TItem();
            ItemsList.Add(newElement);
            return newElement;
        }
    }
}
