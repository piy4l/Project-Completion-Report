using Microsoft.EntityFrameworkCore;
using ProjectCompletionReport.Services;
using Rotativa.AspNetCore;
using Serilog; // Add Serilog namespace

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Log Information level and above by default
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning) // Reduce verbosity for Microsoft logs
    .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning) // Reduce verbosity for System logs
    .WriteTo.File(
        path: "C:\\inetpub\\PCRMS\\Logs\\log-.txt",
        rollingInterval: RollingInterval.Day, // Roll logs daily
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}") // Custom log format
    .CreateLogger();

// Replace default logging with Serilog
builder.Host.UseSerilog();

try
{
    Log.Information("Starting web application");

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve PascalCase
    });

    RotativaConfiguration.Setup(builder.Environment.WebRootPath, "Rotativa");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
    throw; // Re-throw to ensure the app fails visibly during startup issues
}
finally
{
    Log.CloseAndFlush(); // Ensure all logs are written before the app shuts down
}