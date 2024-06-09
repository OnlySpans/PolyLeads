using OnlySpans.PolyLeads.Api.Startup;
using Serilog;

var builder = WebApplication
   .CreateBuilder(args)
   .ConfigureStaticLogger();

try
{
   await builder.ConfigureServices();
   var app = builder.Build();
   await app.Configure();
   await app.RunAsync();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
   Log.Fatal(ex, "Got exception during startup sequence");

#if DEBUG
   throw;
#endif
}
finally
{
   Log.CloseAndFlush();
}
