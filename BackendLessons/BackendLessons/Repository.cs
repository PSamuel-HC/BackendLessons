using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord
{
    internal class Repository<T> where T : class, IEntity, new()
    {
        private List<T> _items = new List<T>();

        private Guid id = Guid.NewGuid();


        public void Add(T entity) 
        {
            _items.Add(entity);
        }

        public T CreateNew()
        {
            return new T();
        }
    }

    internal class ReferenceTest<TFirstEntity, TSecondEntity> where TFirstEntity : TSecondEntity
    {

    }
}
