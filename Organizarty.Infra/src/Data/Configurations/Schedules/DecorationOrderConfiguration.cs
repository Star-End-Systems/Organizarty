using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class DecorationOrderConfiguration : IEntityTypeConfiguration<DecorationOrder>
{
    public void Configure(EntityTypeBuilder<DecorationOrder> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasPrecision(7, 2);
        builder.Property(x => x.EventDate).IsRequired();
        builder.Property(x => x.Note).HasMaxLength(256);
    }
}
