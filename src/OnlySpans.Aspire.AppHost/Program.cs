var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres", password: "postgres")
    .WithVolumeMount("onlyspans-pd-data", "/var/lib/postgresql/data");

var api = builder
    .AddProject<Projects.OnlySpans_PolyLeads_Api>("api")
    .WithReference(postgres);

builder
    .AddProject<Projects.OnlySpans_PolyLeads_ReverseProxy>("reverse-proxy")
    .WithReference(api);

builder
    .Build()
    .Run();
