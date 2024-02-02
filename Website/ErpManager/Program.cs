using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// Add multiple language
builder.Services.AddLocalization(option => option.ResourcesPath = "Resources");    
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedLanguage = new[]
    {
        new CultureInfo("vi-VN"),
        new CultureInfo("en-US"),
    };

    options.DefaultRequestCulture = new RequestCulture("vi-VN");
    options.SupportedCultures = supportedLanguage;
    options.SupportedUICultures = supportedLanguage;
});

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

// Dependency injection
builder.Services.AddScoped<IUserService, UserService>();

// Connection database
var connection = builder.Configuration.GetConnectionString("ErpManager");
builder.Services.AddDbContext<DBContext>(x => x.UseSqlServer(connection, b => b.MigrationsAssembly("ErpManager.Web")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var localizationOptions = scope.ServiceProvider
        .GetRequiredService<IOptions<RequestLocalizationOptions>>()
        .Value;
    app.UseRequestLocalization(localizationOptions);
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "Features",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
