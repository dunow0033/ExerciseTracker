//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using ExerciseTracker.Context;
//using ExerciseTracker.Controllers;
//using ExerciseTracker.Repository;
//using ExerciseTracker.Services;
//using Microsoft.Extensions.Configuration;

//var builder = Host.CreateApplicationBuilder(args);

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

//builder.Services.AddDbContext<ExerciseContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ExerciseConnection"));
//    //options.UseSqlServer("Server=DESKTOP-0CKL8LL\\SQLEXPRESS;Database=ExerciseDB;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True;Encrypt=False;");
//});

//builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
//builder.Services.AddScoped<IExerciseService, ExerciseService>();
//builder.Services.AddScoped<IUserInterface, UserInterface>();
//builder.Services.AddScoped<ExerciseController>();
//builder.Logging.ClearProviders();

//var app = builder.Build();

//using(var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<ExerciseContext>();
//        context.Database.Migrate();
//    }
//    catch(Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while migrating the database");
//    }
//}

////var scope = app.Services.CreateScope();

//var exerciseServices = app.Services.CreateScope().ServiceProvider;
//var exerciseController = exerciseServices.GetRequiredService<ExerciseController>();

//exerciseController.Run();



using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExerciseTracker;

internal static class Program
{
    private static readonly IConfiguration configuration;
    static Program()
    {
        configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }
    static void Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        IServiceProvider exerciseServiceProvider = host.Services;
        IExerciseController? exerciseController = exerciseServiceProvider.GetService<IExerciseController>();
        exerciseController!.Run();
    }
    static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) => {
            services.AddDbContext<ExerciseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ExerciseConnection"));
            })
            .AddScoped<IExerciseRepository, ExerciseRepository>()
            .AddScoped<IExerciseService, ExerciseService>()
            .AddScoped<IExerciseController, ExerciseController>()
            .AddScoped<IUserInterface, UserInterface>();
        });
    }
}











//using ExerciseTracker.Context;
//using ExerciseTracker.Controllers;
//using ExerciseTracker.Repository;
//using ExerciseTracker.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//internal static class Program
//{
//    private static readonly IConfiguration configuration;
//    static Program()
//    {
//        configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//    }
//    static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();

//        //IServiceProvider exerciseServiceProvider = host.Services;
//        //IExerciseController? exerciseController = exerciseServiceProvider.GetService<IExerciseController>();
//        //exerciseController!.Run();

//    }
//    static IHostBuilder CreateHostBuilder(string[] args)
//    {
//        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
//        {
//            services.AddDbContext<ExerciseContext>(options =>
//            {
//                options.UseSqlServer(configuration.GetConnectionString("ExerciseConnection"));
//            })
//            .AddScoped<IExerciseRepository, ExerciseRepository>()
//            .AddScoped<IExerciseService, ExerciseService>()
//            .AddScoped<IExerciseController, ExerciseController>();
//        });
//    }
//}
