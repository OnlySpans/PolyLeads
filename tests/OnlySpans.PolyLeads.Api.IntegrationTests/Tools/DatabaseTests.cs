using DotNet.Testcontainers.Builders;
using Marten;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Data.Entities;
using OnlySpans.PolyLeads.Api.Startup;
using Testcontainers.PostgreSql;

namespace OnlySpans.PolyLeads.Api.Tests.Tools;

public abstract class DatabaseTests : IAsyncLifetime
{
    private PostgreSqlContainer DbContainer { get; } = new PostgreSqlBuilder()
       .WithImage("postgres:latest")
       .WithDatabase("postgres")
       .WithUsername("postgres")
       .WithPassword("postgres")
       .WithPortBinding(Random.Shared.Next(10000, 60000), 5432)
       .WithWaitStrategy(Wait.ForUnixContainer()
           .UntilPortIsAvailable(5432))
       .Build();

    protected ApplicationDbContext Context { get; set; } = default!;

    protected ISender Sender { get; set; } = default!;

    protected UserManager<ApplicationUser> UserManager { get; set; } = default!;

    private AsyncServiceScope Scope { get; set; } = default!;

    async Task IAsyncLifetime.InitializeAsync()
    {
        await DbContainer.StartAsync();

        var serviceProvider = new ServiceCollection()
           .AddIdentity()
           .AddLogging()
           .AddMediator()
           .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(DbContainer.GetConnectionString());
            })
           .AddSingleton<IHostEnvironment>(new HostingEnvironment {EnvironmentName = "Development"})
           .AddSingleton(Substitute.For<IMartenLogger>())
           .BuildServiceProvider();

        Scope = serviceProvider.CreateAsyncScope();

        Sender = Scope
           .ServiceProvider
           .GetRequiredService<ISender>();

        UserManager = Scope
           .ServiceProvider
           .GetRequiredService<UserManager<ApplicationUser>>();

        Context = Scope
           .ServiceProvider
           .GetRequiredService<ApplicationDbContext>();

        await Context
           .Database
           .MigrateAsync();

        await InitializeAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DisposeAsync();

        await Scope.DisposeAsync();

        await DbContainer.StopAsync();
    }

    protected virtual async Task InitializeAsync() { }

    protected virtual async Task DisposeAsync() { }
}