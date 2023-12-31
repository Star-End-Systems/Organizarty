using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class DecorationInfoConfiguration : IEntityTypeConfiguration<DecorationInfo>
{
    public void Configure(EntityTypeBuilder<DecorationInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(new NanoidConverter());
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Color).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Material).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Price).IsRequired().HasPrecision(7, 2);
    }
}
