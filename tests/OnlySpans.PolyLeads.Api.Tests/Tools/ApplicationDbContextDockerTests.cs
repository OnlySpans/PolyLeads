using DotNet.Testcontainers.Builders;
using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using Testcontainers.PostgreSql;

namespace OnlySpans.PolyLeads.Api.Tests.Tools;

public abstract class ApplicationDbContextDockerTests : IAsyncLifetime
{
    private PostgreSqlContainer DbContainer { get; init; } = new PostgreSqlBuilder()
       .WithImage("postgres:latest")
       .WithDatabase("postgres")
       .WithUsername("postgres")
       .WithPassword("postgres")
       .WithPortBinding(Random.Shared.Next(10000, 60000), 5432)
       .WithWaitStrategy(Wait.ForUnixContainer()
           .UntilPortIsAvailable(5432))
       .Build();

    protected ApplicationDbContext Context { get; private set; } = default!;

    public virtual async Task InitializeAsync()
    {
        await DbContainer.StartAsync();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseNpgsql(DbContainer.GetConnectionString())
           .Options;

        Context = new(options);
        await Context.Database.MigrateAsync();
    }

    public virtual async Task DisposeAsync()
    {
        await Context.DisposeAsync();
        await DbContainer.StopAsync();
    }
}