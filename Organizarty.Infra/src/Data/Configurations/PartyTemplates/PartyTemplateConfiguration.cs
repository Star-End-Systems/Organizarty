using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class PartyTemplateConfiguration : IEntityTypeConfiguration<PartyTemplate>
{
    public void Configure(EntityTypeBuilder<PartyTemplate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ExpectedGuests).IsRequired();

        builder.Property(x => x.Type).IsRequired();

        builder.HasOne(a => a.User)
          .WithMany()
          .HasForeignKey(a => a.UserId);

        builder.HasOne(a => a.Location)
          .WithMany()
          .HasForeignKey(a => a.LocationId);

        builder.HasOne(a => a.OriginalPartyTemplate)
          .WithMany()
          .HasForeignKey(a => a.OriginalPartyTemplateId);
    }
}
