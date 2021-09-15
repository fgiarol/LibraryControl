using System.Collections.Generic;
using System.Linq;

namespace LibraryControl.Domain.Entities
{
    public class Genre : Entity
    {
        private IList<Book> _books;

        public Genre() { }
        public Genre(string name)
        {
            Name = name;
        }
        
        public string Name { get; private set; }
        public IReadOnlyCollection<Book> Books => _books.ToArray();
    }
}