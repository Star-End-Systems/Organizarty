using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class ServiceInfoConfiguration : IEntityTypeConfiguration<ServiceInfo>
{
    public void Configure(EntityTypeBuilder<ServiceInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Plan).IsRequired().HasMaxLength(64);
        builder.Property(x => x.Price).IsRequired().HasPrecision(7, 2);

        builder.Ignore(x => x.Images);
    }
}
