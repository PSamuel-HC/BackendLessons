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

    }

    internal record Simple { }
}
