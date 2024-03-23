var builder = DistributedApplication.CreateBuilder(args);

var api = builder
   .AddProject<Projects.OnlySpans_PolyLeads_Api>("api");

builder
   .AddProject<Projects.OnlySpans_PolyLeads_ReverseProxy>("reverse-proxy")
   .WithReference(api);

builder
   .Build()
   .Run();
