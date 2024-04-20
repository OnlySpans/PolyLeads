using OnlySpans.PolyLeads.Api;

var builder = WebApplication
   .CreateBuilder(args)
   .ConfigureStaticLogger();

await builder.ConfigureServices();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

await app.Configure();
await app.RunAsync();