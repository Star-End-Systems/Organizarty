using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Party.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class ServiceGroupConfiguration : IEntityTypeConfiguration<ServiceGroup>
{
    public void Configure(EntityTypeBuilder<ServiceGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Note).IsRequired().HasMaxLength(256);

        builder.HasOne(a => a.ServiceInfo)
          .WithMany()
          .HasForeignKey(a => a.ServiceInfoId);

        builder.HasOne(a => a.PartyTemplate)
          .WithMany()
          .HasForeignKey(a => a.PartyTemplateId);
    }
}
