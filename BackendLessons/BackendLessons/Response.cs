using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.GoldenRecord
{
    internal class Response<T>
    {
        public int HttpStatusCode {  get; set; }

        public string Message { get; set; }

        public T ResponseBody { get; set; }
    }

    internal class Page<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public List<T> ElementList { get; set; }
    }

    internal class User : IEntity
    {
        public int Rank { get; set; }

        public User()
        {

        }

        public User(int param)
        {

        }
    }

    internal class Product
    {
        public Guid? Id { get; set; }

        public string? ProductName { get; set; }

        public double Price { get; set; }

        public Product()
        {

        }

        public Product(Guid guid, string productName, double price)
        {
            Id = guid;
            ProductName = productName;
            Price = price;
        }
    }

    internal record Simple { }
}
