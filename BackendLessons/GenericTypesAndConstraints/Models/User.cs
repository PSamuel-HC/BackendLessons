namespace GenericTypesAndConstraints.Models
{
    internal class User: IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;

        public User()
        {
        }

        public User(Guid id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
