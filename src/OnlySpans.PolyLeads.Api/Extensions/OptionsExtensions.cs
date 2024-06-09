using System.Reflection;
using OnlySpans.PolyLeads.Api.Data.Abstractions.Options;

namespace OnlySpans.PolyLeads.Api.Extensions;

/// <summary>
/// Методы расширения для использоавния опций.
/// </summary>
public static class OptionsExtensions
{
    private delegate IServiceCollection Configure(
        IServiceCollection services,
        IConfiguration configuration);

    private static MethodInfo ConfigureMethodInfo { get; }

    static OptionsExtensions()
    {
        Type[] parameterTypes = [typeof(IServiceCollection), typeof(IConfiguration)];
        const string methodName = nameof(OptionsConfigurationServiceCollectionExtensions.Configure);

        ConfigureMethodInfo = typeof(OptionsConfigurationServiceCollectionExtensions)
           .GetMethod(methodName, parameterTypes)!;
    }

    /// <summary>
    /// Добавляет IOptions[T] для всех типов в сборке, реализующих
    /// <see cref="IApplicationOptions"/>
    /// </summary>
    public static WebApplicationBuilder AddOptions(
        this WebApplicationBuilder builder,
        Assembly? assembly = null)
    {
        assembly ??= Assembly.GetExecutingAssembly();

        foreach (var type in GetConfigurationTypes(assembly))
        {
            var property = type.GetProperty(
                nameof(IApplicationOptions.Section),
                BindingFlags.Public | BindingFlags.Static);

            var key = (string) property!.GetValue(null)!;

            var section = GetConfigurationSection(builder, key);

            var configure = BuildConfigureMethod(type);

            configure(builder.Services, section);
        }

        return builder;
    }

    private static IConfiguration GetConfigurationSection(WebApplicationBuilder builder, string key)
    {
        if (key == string.Empty)
            return builder.Configuration;

        return builder.Configuration.GetRequiredSection(key);
    }

    private static List<Type> GetConfigurationTypes(Assembly assembly) =>
        assembly
           .GetTypes()
           .Where(t => t.IsAssignableTo(typeof(IApplicationOptions)))
           .Where(t => t is {IsInterface: false, IsAbstract: false})
           .ToList();

    private static Configure BuildConfigureMethod(Type type)
    {
        const object? staticTarget = null;

        return ConfigureMethodInfo
           .MakeGenericMethod(type)
           .CreateDelegate<Configure>(staticTarget);
    }
}
