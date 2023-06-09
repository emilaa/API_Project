using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Color).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Price).IsRequired().HasPrecision(18, 4);
            builder.Property(m => m.Year).IsRequired().HasDefaultValue(DateTime.UtcNow);
        }
    }
}
