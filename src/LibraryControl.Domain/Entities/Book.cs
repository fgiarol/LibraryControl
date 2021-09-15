using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryControl.Domain.Entities
{
    public class Book : Entity
    {
        private readonly List<Genre> _genres;
        private readonly List<Author> _authors;
        private readonly List<Reserve> _reserves;

        public Book() { }
        public Book(string name, User userCreation, string synopsis = "")
        {
            Name = name;
            UserCreation = userCreation;
            Synopsis = synopsis;
            _genres = new List<Genre>();
            _authors = new List<Author>();
            _reserves = new List<Reserve>();
        }
        
        public string Name { get; private set; }
        public uint Quantity { get; private set; }
        public User UserCreation { get; private set; }
        public Guid UserCreationId { get; private set; }
        public string Synopsis { get; private set; }
        public IReadOnlyCollection<Genre> Genres => _genres.ToArray();
        public IReadOnlyCollection<Author> Authors => _authors.ToArray();
        public IReadOnlyCollection<Reserve> Reserves => _reserves.ToArray();

        public void Update(string name, string synopsis) 
        {
            Name = name;
            Synopsis = synopsis;
        }
        
        public void LinkGenre(Genre genre)
        {
            _genres.Add(genre);
        }
        
        public void LinkGenres(List<Genre> genres)
        {
            _genres.AddRange(genres);
        }
        
        public void RemoveGenre(Genre genre)
        {
            _genres.Remove(genre);
        }

        //TODO: implementar metodo de identificacao de livros iguais para definicao de quantidade
    }
}