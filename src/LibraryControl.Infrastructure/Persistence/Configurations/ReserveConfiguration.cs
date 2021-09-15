using LibraryControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryControl.Infrastructure.Persistence.Configurations
{
    public class ReserveConfiguration : BaseEntityConfiguration<Reserve>
    {
        public override void Configure(EntityTypeBuilder<Reserve> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Returned)
                .HasDefaultValue(false)
                .IsRequired();
            
            builder.Property(r => r.ReserveDate)
                .IsRequired(false);

            builder.ToTable("Reserves");
        }
    }
}