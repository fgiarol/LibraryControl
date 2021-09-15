using System.Collections.Generic;
using System.Linq;
using LibraryControl.Domain.Enums;

namespace LibraryControl.Domain.Entities
{
    public class Author : Entity
    {
        private readonly IList<Book> _books;

        public Author() { }
        public Author(string name, ushort age, EGender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; private set; }
        public ushort? Age { get; private set; }
        public EGender? Gender { get; private set; }
        public string Description { get; set; }
        public IReadOnlyCollection<Book> Books => _books.ToArray();
        
        public void LinkBook(Book book)
        {
            _books.Add(book);
        }
    }
}