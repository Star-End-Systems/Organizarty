using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Locations.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(256);

        builder.Property(x => x.Category).IsRequired().HasMaxLength(32);

        builder.Property(x => x.RentPerDay).IsRequired().HasPrecision(7, 2);

        builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);

        builder.Property(x => x.Cords).IsRequired().HasMaxLength(16);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(32);

        builder.Ignore(x => x.Images);
    }
}
