using Organizarty.DependencyInversion.Infra.Database;
using Organizarty.DependencyInversion.Infra.Providers;
using Organizarty.DependencyInversion.Infra.Repositories;
using Organizarty.UI.Extensions;

using Organizarty.DependencyInversion.Application.UseCasesExtensions;

using DotNetEnv;
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddProviders();

builder.Services.AddUseCases();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHelpers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();

}
else if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
