var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres(
        name: "postgres",
        port: 5432,
        password: "postgres")
    .WithVolumeMount(
        "onlyspans-pd-data",
        "/var/lib/postgresql/data");

var api = builder
    .AddProject<Projects.OnlySpans_PolyLeads_Api>("api")
    .WithReference(postgres);

var ui = builder
   .AddNpmApp(
        name: "ui",
        workingDirectory: "../onlyspans.polyleads.ui",
        scriptName: "dev")
   .WithEndpoint(
        containerPort: 3000,
        hostPort: 3000,
        scheme: "http",
        env: "PORT");

builder
    .AddProject<Projects.OnlySpans_PolyLeads_ReverseProxy>("reverse-proxy")
    .WithReference(api)
    .WithReference(ui);

builder
    .Build()
    .Run();
