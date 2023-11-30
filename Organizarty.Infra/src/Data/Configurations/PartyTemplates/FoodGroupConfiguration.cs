using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class FoodGroupConfiguration : IEntityTypeConfiguration<FoodGroup>
{
    public void Configure(EntityTypeBuilder<FoodGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Note).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(a => a.FoodInfo)
          .WithMany()
          .HasForeignKey(a => a.FoodInfoId);

        builder.HasOne(a => a.PartyTemplate)
          .WithMany()
          .HasForeignKey(a => a.PartyTemplateId);
    }
}
