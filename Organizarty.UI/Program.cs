using Organizarty.DependencyInversion.Infra.Database;
using Organizarty.DependencyInversion.Infra.Providers;
using Organizarty.DependencyInversion.Infra.Repositories;
using Organizarty.UI.Extensions;

using Organizarty.DependencyInversion.Application.UseCasesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTextCompression();

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration)
                .AddRepositories()
                .AddRepositories()
                .AddProviders()
                .AddUseCases();

builder.Services.AddControllers();

builder.Services.AddHelpers();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseResponseCompression();

app.UseExceptionHandler("/Error");

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseRedirectMiddleware();

// app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
