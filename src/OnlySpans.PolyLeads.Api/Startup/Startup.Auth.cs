using OnlySpans.PolyLeads.Api.Data.Contexts;

namespace OnlySpans.PolyLeads.Api.Startup;

public static partial class Startup
{
    private static WebApplicationBuilder AddAuth(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddAuthentication();
        services.AddAuthorization();

        return builder;
    }

    private static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
    {
        builder
           .Services
           .AddIdentity();

        return builder;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
           .AddIdentity<Entities.ApplicationUser, Entities.ApplicationUserRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>();

        services.ConfigureApplicationCookie(options =>
        {
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                return Task.CompletedTask;
            };

            options.Events.OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                return Task.CompletedTask;
            };
        });

        return services;
    }
}