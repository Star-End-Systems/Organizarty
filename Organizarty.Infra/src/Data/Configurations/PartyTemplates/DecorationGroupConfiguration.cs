using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class DecorationGroupConfiguration : IEntityTypeConfiguration<DecorationGroup>
{
    public void Configure(EntityTypeBuilder<DecorationGroup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Note).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(a => a.DecorationInfo)
          .WithMany()
          .HasForeignKey(a => a.DecorationInfoId);

        builder.HasOne(a => a.PartyTemplate)
          .WithMany()
          .HasForeignKey(a => a.PartyTemplateId);
    }
}
