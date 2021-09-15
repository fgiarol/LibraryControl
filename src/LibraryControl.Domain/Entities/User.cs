using System.Collections.Generic;
using System.Linq;
using LibraryControl.Domain.ValueObjects;

namespace LibraryControl.Domain.Entities
{
    public class User : Entity
    {
        private readonly IList<Book> _books;
        private readonly IList<Reserve> _reserves;

        public User() { }
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
        public IReadOnlyCollection<Book> Books => _books.ToArray();
        public IReadOnlyCollection<Reserve> Reserves => _reserves.ToArray();
        
        public void AddBook(Book book)
        {
            _books.Add(book);
        }
        
        public void ReserveBook(Reserve reserve)
        {
            //TODO: antes de fazer a reserva, validar se há disponibilidade
            _reserves.Add(reserve);
        }
    }
}