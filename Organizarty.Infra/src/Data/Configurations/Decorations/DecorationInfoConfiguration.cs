using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.DecorationInfos.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class DecorationInfoConfiguration : IEntityTypeConfiguration<DecorationInfo>
{
    public void Configure(EntityTypeBuilder<DecorationInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Color).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Material).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Price).IsRequired().HasPrecision(2);
    }
}
