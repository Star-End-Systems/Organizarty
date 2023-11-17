using Organizarty.DependencyInversion.Infra.Database;
using Organizarty.DependencyInversion.Infra.Providers;
using Organizarty.DependencyInversion.Infra.Repositories;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
else if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseAuthorization();

app.MapControllers();

app.MapRazorPages();

// app.MapAreaControllerRoute(
//     name: "InitialArea",
//     areaName: "Api",
//     pattern: "api/{controller=Party}/{action=Index}/{id?}");

app.Run();
