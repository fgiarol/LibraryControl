using LibraryControl.Domain.ValueObjects;

namespace LibraryControl.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, Email email, string password, bool admin)
        {
            Name = name;
            Email = email;
            Password = password;
            Admin = admin;
        }

        public string Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public bool Admin { get; private set; }
    }
}