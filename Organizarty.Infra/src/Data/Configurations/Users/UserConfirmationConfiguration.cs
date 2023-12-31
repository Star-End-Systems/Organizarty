using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class UserConfirmationConfiguration : IEntityTypeConfiguration<UserConfirmation>
{
    public void Configure(EntityTypeBuilder<UserConfirmation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        // TODO: Add an index
        builder.Property(x => x.Code).HasMaxLength(8);

        builder.Property(x => x.UserEmail).IsRequired();
    }
}
