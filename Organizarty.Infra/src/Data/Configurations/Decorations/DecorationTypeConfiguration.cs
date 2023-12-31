using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class DecorationTypeConfiguration : IEntityTypeConfiguration<DecorationType>
{
    public void Configure(EntityTypeBuilder<DecorationType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasConversion(new NanoidConverter());
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Size).IsRequired().HasMaxLength(8);
        builder.Property(x => x.Model).IsRequired().HasMaxLength(512);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(256);
        builder.Property(x => x.ObjectURL).IsRequired();

        builder
          .HasMany(x => x.Decorations)
          .WithOne(x => x.DecorationType)
          .HasForeignKey(x => x.DecorationTypeId);

        builder.Ignore(x => x.Tags);
    }
}
