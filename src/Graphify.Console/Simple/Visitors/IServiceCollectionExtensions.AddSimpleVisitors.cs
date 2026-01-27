namespace Graphify.Console.Simple.Visitors;

using System;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides dependency injection registrations for simple visitors.
/// </summary>
public static partial class IServiceCollectionExtensions
{
    /// <summary>
    /// Registers the simple visitors in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to update.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddSimpleVisitors(this IServiceCollection services)
    {
        return services
            .AddSingleton<IVisitor<Simple, string>, Root>()
            .AddSingleton<IVisitor<Simple.Graph.Age, string>, Age>()
            .AddSingleton<IVisitor<Simple.Graph.IsAdult, string>, IsAdult>()
            .AddSingleton<IVisitor<Simple.Graph.Name, string>, Name>()
            .AddSingleton<IVisitor<Simple.Graph.Name.Length, string>, NameLength>();
    }
}