using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryControl.Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration: BaseEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Name)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            
            builder.Property(a => a.Age)
                .HasColumnType("tinyint")
                .IsRequired(false);
            
            builder.Property(a => a.Gender)
                .HasConversion<string>()
                .IsRequired(false);

            builder.HasMany(a => a.Books)
                .WithMany(b => b.Authors);

            builder.ToTable("Authors");
        }
    }
}