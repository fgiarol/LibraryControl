using System;

namespace LibraryControl.Domain.Entities
{
    public class Reserve : Entity
    {
        public Reserve(User user, Book book)
        {
            User = user;
            Book = book;
            ReserveDate = DateTime.UtcNow;
            Returned = false;
        }

        public DateTime ReserveDate { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }
        public Book Book { get; private set; }
        public Guid BookId { get; private set; }
        public bool Returned { get; private set; }

        public void Return()
        {
            Returned = true;
        }
    }
}
