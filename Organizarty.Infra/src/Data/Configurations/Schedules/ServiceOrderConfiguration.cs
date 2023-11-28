using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Schedules.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Price).IsRequired().HasPrecision(5, 2);
        builder.Property(x => x.EventDate).IsRequired();
        builder.Property(x => x.Note).HasMaxLength(256);

        builder.HasOne(a => a.ThirdParty)
                .WithMany()
                .HasForeignKey(a => a.ThirdPartyId);
    }
}
