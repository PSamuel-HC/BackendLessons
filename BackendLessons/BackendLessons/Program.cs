using Jalasoft.GoldenRecord;
using System.Collections;

namespace BackendLessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Response<User> userResponse = new Response<User>();

            Response<Product> productResponse = new Response<Product>();

            Response<Page<User>> userPaginatedResponse = new Response<Page<User>>();

            Repository<User> product = new Repository<User>();

        }
    }
}
