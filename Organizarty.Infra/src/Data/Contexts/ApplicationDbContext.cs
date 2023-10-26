using Microsoft.EntityFrameworkCore;
using Organizarty.Application.App.DecorationInfos.Entities;
using Organizarty.Application.App.DecorationTypes.Entities;
using Organizarty.Application.App.FoodInfos.Entities;
using Organizarty.Application.App.FoodTypes.Entities;
using Organizarty.Application.App.Locations.Entities;
using Organizarty.Application.App.Party.Entities;
using Organizarty.Application.App.Schedules.Entities;
using Organizarty.Application.App.ServiceInfos.Entities;
using Organizarty.Application.App.ServiceTypes.Entities;
using Organizarty.Application.App.ThirdParties.Entities;
using Organizarty.Application.App.Users.Entities;

namespace Organizarty.Infra.Data.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserConfirmation> UserConfirmations { get; set; } = default!;

    public DbSet<ThirdParty> ThirdParties { get; set; } = default!;

    public DbSet<FoodType> FoodTypes { get; set; } = default!;
    public DbSet<FoodInfo> FoodInfos { get; set; } = default!;

    public DbSet<DecorationType> DecorationTypes { get; set; } = default!;
    public DbSet<DecorationInfo> DecorationInfos { get; set; } = default!;

    public DbSet<ServiceType> ServiceTypes { get; set; } = default!;
    public DbSet<ServiceInfo> ServiceInfos { get; set; } = default!;

    public DbSet<Location> Locations { get; set; } = default!;

    public DbSet<Schedule> Schedules { get; set; } = default!;
    public DbSet<DecorationOrder> DecorationOrders { get; set; } = default!;
    public DbSet<ServiceOrder> ServiceOrders { get; set; } = default!;
    public DbSet<FoodOrder> FoodOrders { get; set; } = default!;

    public DbSet<PartyTemplate> PartyTemplates { get; set; } = default!;
    public DbSet<FoodGroup> FoodGroups { get; set; } = default!;
    public DbSet<DecorationGroup> DecorationGroups { get; set; } = default!;
    public DbSet<ServiceGroup> ServiceGroups { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
