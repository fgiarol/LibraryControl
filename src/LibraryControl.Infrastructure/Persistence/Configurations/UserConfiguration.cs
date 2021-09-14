using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryControl.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration: BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.OwnsOne(u => u.Email,
                navigationBuilder =>
                {
                    navigationBuilder.Property(e => e.Address)
                        .HasColumnName("Address")
                        .IsRequired();
                });
            
            builder.Property(u => u.Password)
                .IsRequired();
            
            builder.Property(u => u.Admin)
                .HasDefaultValue(false)
                .IsRequired();
            
            builder.HasMany(u => u.Books)
                .WithOne(b => b.UserCreation)
                .HasForeignKey(b => b.UserCreationId);
            
            builder.HasMany(u => u.Reserves)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
            
            builder.ToTable("Users");
        }
    }
}