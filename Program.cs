using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GourmandGurus.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages((options =>
{
    options.Conventions.AuthorizeFolder("/Recipes");
    options.Conventions.AllowAnonymousToPage("/Recipes/Index");
    options.Conventions.AllowAnonymousToPage("/Recipes/Details");

}));

builder.Services.AddDbContext<GourmandGurusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GourmandGurusContext") ?? throw new InvalidOperationException("Connection string 'GourmandGurusContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("GourmandGurusContext") ?? throw new InvalidOperationException("Connection string 'GourmandGurusContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
 .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.555
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
