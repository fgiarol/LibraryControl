using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryControl.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : BaseEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Name)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            
            builder.Property(b => b.Quantity)
                .IsRequired();

            builder.Property(b => b.Synopsis)
                .HasColumnType("nvarchar(1000)")
                .IsRequired(false);
            
            builder.HasMany(b => b.Reserves)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId);
            
            builder.HasMany(b => b.Genres)
                .WithMany(g => g.Books);
            
            builder.ToTable("Books");
        }
    }
}