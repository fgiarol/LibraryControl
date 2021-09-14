using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryControl.Infrastructure.Persistence.Configurations
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> 
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}