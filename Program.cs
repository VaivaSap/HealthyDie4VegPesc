using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using VegApp;
using VegApp.Areas.Identity.Data;
using VegApp.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VegAppContextConnection") ?? throw new InvalidOperationException("Connection string 'VegAppContextConnection' not found.");

builder.Services.AddDbContext<VegAppContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<VegAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<VegAppContext>();

ProductImporter.ImportProduct();

// Add services to the container.


builder.Services.AddRazorPages();
builder.Services.AddScoped<UserProvider>();
builder.Services.AddScoped<PersonalizedRecommendation>();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
