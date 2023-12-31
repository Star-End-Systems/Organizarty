using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Infra.Utils;

namespace Organizarty.Infra.Data.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasMaxLength(IdGenerator.ID_SIZE);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.ExpectedGuests).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasPrecision(7, 2);

        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.LocationId).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.PartyId).IsRequired();

        builder.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt).ValueGeneratedOnAddOrUpdate();
    }
}
