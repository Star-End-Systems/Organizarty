using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
{
    public void Configure(EntityTypeBuilder<FoodOrder> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasPrecision(7, 2);
        builder.Property(x => x.EventDate).IsRequired();
        builder.Property(x => x.Note).HasMaxLength(256);

        builder.HasOne(x => x.ThirdParty)
                .WithMany()
                .HasForeignKey(x => x.ThirdPartyId);
    }
}
