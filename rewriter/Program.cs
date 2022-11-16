using Db.Context.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using rewriter.api.Configuration;
using rewriter.Data;
using rewriter.OrderService;
using rewriter.Settings.Settings;
using rewriter.Settings.Source;
using rewriter.Shared.Common.Helpers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("MainDbContext");
//builder.Services.AddDbContextFactory<MainDbContext>(
//        options =>
//            options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var settings = new ApiSettings(new SettingsSource());
builder.Services.AddAppDbContext(settings);
//builder.Services.AddCors();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowAnyOrigin();
}));


builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration
     .Enrich.WithCorrelationId()
     .ReadFrom.Configuration(hostBuilderContext.Configuration);
});
builder.Services.AddOrderService();
AutoMappersRegisterHelper.Register(builder.Services);
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAppHealthCheck().AddControllersWithViews().AddValidator();
builder.Services.AddAppAuth();
//builder.Services.AddOrderService();
var app = builder.Build();
app.UseCors("MyPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAppDbContext();
app.UseAppAuth();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
