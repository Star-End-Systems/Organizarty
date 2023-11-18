using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Services.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(256);

        builder.HasMany(a => a.SubServices)
          .WithOne(b => b.ServiceType)
          .HasForeignKey(a => a.ServiceTypeId);

        builder.Ignore(x => x.Tags);
    }
}
