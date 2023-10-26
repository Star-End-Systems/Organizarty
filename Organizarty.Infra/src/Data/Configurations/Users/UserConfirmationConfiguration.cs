using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Infra.Data.Configurations;

public class UserConfirmationConfiguration : IEntityTypeConfiguration<UserConfirmation>
{
    public void Configure(EntityTypeBuilder<UserConfirmation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.HasOne(a => a.User)
          .WithMany()
          .HasForeignKey(a => a.UserId);
    }
}
