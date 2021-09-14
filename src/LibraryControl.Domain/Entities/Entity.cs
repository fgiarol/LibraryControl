using System;

namespace LibraryControl.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; private set; }
    }
}