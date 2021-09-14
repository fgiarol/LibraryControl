using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryControl.Domain.Entities
{
    public class Book : Entity
    {
        private readonly IList<Genre> _genres;
        private readonly IList<Author> _authors;
        private readonly IList<Reserve> _reserves;
        
        public Book(string name, User userCreation, string synopsis)
        {
            Name = name;
            UserCreation = userCreation;
            Synopsis = synopsis;
        }
        
        public string Name { get; private set; }
        public uint Quantity { get; private set; }
        public User UserCreation { get; private set; }
        public Guid UserCreationId { get; private set; }
        public string Synopsis { get; private set; }
        public IReadOnlyCollection<Genre> Genres => _genres.ToArray();
        public IReadOnlyCollection<Author> Authors => _authors.ToArray();
        public IReadOnlyCollection<Reserve> Reserves => _reserves.ToArray();

        public void AddBookGenre(Genre genre)
        {
            _genres.Add(genre);
        }

        public void ReserveBook(Reserve reserve)
        {
            //TODO: antes de fazer a reserva, validar se há disponibilidade
            _reserves.Add(reserve);
        }
        
        //TODO: implementar metodo de identificacao de livros iguais para definicao de quantidade
    }
}