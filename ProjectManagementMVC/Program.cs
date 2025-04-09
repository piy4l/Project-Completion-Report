//Author:
//Souvik Das
//Assistant Programmer, BCC
//BSc in CSE, BUET
//PhD Student, Department of CSCE, Texas A&M University 

using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Services;
using Rotativa.AspNetCore;
using Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.File(
        path: "C:\\inetpub\\PCRMS\\Logs\\log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();

try
{
    Log.Information("Starting web application");

    // Add services to the container
    builder.Services.AddControllersWithViews(options =>
    {
        options.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter());
    });

    builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login";
            options.LogoutPath = "/Login/Logout";
            options.AccessDeniedPath = "/Home/AccessDenied";
            options.ExpireTimeSpan = TimeSpan.FromHours(1); // Default expiration for persistent cookies
            options.SlidingExpiration = true; // Renew expiration on activity
        });

    RotativaConfiguration.Setup(builder.Environment.WebRootPath, "Rotativa");

    var app = builder.Build();

    // Apply database migrations on startup [comment-in before publishing]
    //using (var scope = app.Services.CreateScope())
    //{
    //    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    //    try
    //    {
    //        Log.Information("Applying database migrations...");
    //        dbContext.Database.Migrate(); // Applies all pending migrations
    //        Log.Information("Database migrations applied successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Error(ex, "Failed to apply database migrations.");
    //        throw; // Re-throw to ensure startup fails if migrations fail
    //    }
    //}

    // Configure the HTTP request pipeline
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication(); // Must be before UseAuthorization
    app.UseAuthorization();

    // Custom middleware to redirect root URL based on authentication
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/" && context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Home/Index");
            return;
        }
        await next();
    });

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
    throw;
}
finally
{
    Log.CloseAndFlush();
}