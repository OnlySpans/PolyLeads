using OnlySpans.PolyLeads.Api;

var builder = WebApplication
   .CreateBuilder(args)
   .ConfigureStaticLogger();

await builder.ConfigureServices();
var app = builder.Build();
await app.Configure();
await app.RunAsync();