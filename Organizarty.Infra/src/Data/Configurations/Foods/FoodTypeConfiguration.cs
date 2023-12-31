using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Organizarty.Application.App.Foods.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class FoodTypeConfiguration : IEntityTypeConfiguration<FoodType>
{
    public void Configure(EntityTypeBuilder<FoodType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(new NanoidConverter());
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(35);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(256);

        builder.Ignore(x => x.Tags);

        builder.HasOne(a => a.ThirdParty)
          .WithMany()
          .HasForeignKey(a => a.ThirdPartyId)
          .IsRequired();

        builder.HasMany(a => a.Foods)
          .WithOne(b => b.FoodType)
          .HasForeignKey(a => a.FoodTypeId);
    }
}
