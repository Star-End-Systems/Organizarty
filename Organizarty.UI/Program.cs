using Organizarty.DependencyInversion.Infra.Database;
using Organizarty.DependencyInversion.Infra.Providers;
using Organizarty.DependencyInversion.Infra.Repositories;
using Organizarty.UI.Extensions;

using Organizarty.DependencyInversion.Application.UseCasesExtensions;

using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTextCompression();

// Add services to the container.
builder.Services.AddRazorPages()
  ;
builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration)
                .AddRepositories()
                .AddRepositories()
                .AddProviders()
                .AddUseCases();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

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

app.UseStaticFiles();

app.UseRedirectMiddleware();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

app.Run();
