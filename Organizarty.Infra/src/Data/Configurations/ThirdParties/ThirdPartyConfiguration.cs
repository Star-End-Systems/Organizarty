using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.ThirdParties.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class ThirdPartyConfiguration : IEntityTypeConfiguration<ThirdParty>
{
    public void Configure(EntityTypeBuilder<ThirdParty> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(256);

        builder.Property(x => x.Address).IsRequired().HasMaxLength(256);

        builder.Property(x => x.ContactPhone).IsRequired().HasMaxLength(20);
        builder.Property(x => x.ProfissionalPhone).IsRequired().HasMaxLength(20);

        builder.Property(x => x.ContactEmail).IsRequired().HasMaxLength(256);

        builder.Property(x => x.LoginEmail).IsRequired().HasMaxLength(256);
        builder.HasIndex(x => x.LoginEmail).IsUnique();

        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Salt).IsRequired();

        builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(14);

        builder.Property(x => x.ContactPhone).IsRequired();
        builder.Property(x => x.ProfissionalPhone).IsRequired();
        builder.Property(x => x.ProfilePictureURL).IsRequired();

        builder.Ignore(x => x.Tag);
    }
}
