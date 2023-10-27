using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Email).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Salt).IsRequired();

        builder.Property(x => x.Location).IsRequired();

        builder.Ignore(x => x.Roles);
    }
}
