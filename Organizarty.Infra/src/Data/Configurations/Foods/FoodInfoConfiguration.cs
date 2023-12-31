using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Foods.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class FoodInfoConfiguration : IEntityTypeConfiguration<FoodInfo>
{
    public void Configure(EntityTypeBuilder<FoodInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Flavour).IsRequired().HasMaxLength(35);
        builder.Property(x => x.Price).IsRequired().HasPrecision(7, 2);

        builder.Ignore(x => x.Images);
    }
}
