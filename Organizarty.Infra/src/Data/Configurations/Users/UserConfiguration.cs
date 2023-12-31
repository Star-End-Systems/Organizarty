using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Users.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Fullname).IsRequired().HasMaxLength(80);

        builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);

        builder.Property(x => x.Email).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Salt).IsRequired();

        builder.Property(x => x.Location).IsRequired();

        builder.Property(x => x.CPF).HasMaxLength(11).IsRequired(false);
        builder.HasIndex(x => x.CPF).IsUnique();

        builder.Ignore(x => x.Roles);

        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();
    }
}
