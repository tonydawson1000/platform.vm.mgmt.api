using Platform.Vm.Mgmt.Api;

using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting API...");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
      (context, services, configuration) => configuration
          .ReadFrom.Configuration(context.Configuration)
          .ReadFrom.Services(services)
          .Enrich.FromLogContext()
          .WriteTo.Console(),
      true);

// Throttle the 'Thread Pool' (set to the number of processors)
// ThreadPool.SetMaxThreads(Environment.ProcessorCount, Environment.ProcessorCount);

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

app.UseSerilogRequestLogging();

Log.Information("*!*!* - Resetting database...");
await app.ResetDatabaseAsync();
Log.Information("*!*!* - Resetting database... Done!");

app.Run();