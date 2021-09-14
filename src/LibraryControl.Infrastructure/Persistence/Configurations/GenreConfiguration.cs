using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryControl.Infrastructure.Persistence.Configurations
{
    public class GenreConfiguration : BaseEntityConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);

            builder.Property(g => g.Name)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.ToTable("Genres");
        }
    }
}