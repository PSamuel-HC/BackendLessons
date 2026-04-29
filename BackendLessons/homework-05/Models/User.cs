using homework_05.Interfaces;

namespace homework_05.Models
{
    internal class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public User() {
            Id = 0;
            Username = "";
        }

        public User(int id, string userName)
        {
            Id = id;
            Username = userName;
        }
    }
}
