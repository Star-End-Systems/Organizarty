using Organizarty.Infra.Extensions;

using Organizarty.Application.Extensions;

using DotNetEnv;
Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddProviders();

builder.Services.AddUseCases();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "InitialArea",
    areaName: "Organizarty",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
