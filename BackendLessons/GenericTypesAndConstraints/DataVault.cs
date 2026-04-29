namespace GenericTypesAndConstraints
{
    internal class DataVault<T> where T : class, IEntity, new()
    {
        private List<T> _items = new List<T>();

        public void AddItem(T item)
        {
            Console.WriteLine($"Adding item with Id: {item.Id}");
            _items.Add(item);
        }

        public T? GetById(Guid id)
        {
            T? bookFound = _items.Find(b => b.Id == id);
            return bookFound;
        }
        public T CreateAndAdd()
        {
            T newItem = new T();
            AddItem(newItem);
            return newItem;
        }
    }
}
