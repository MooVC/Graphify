namespace Graphify.Console.Complex.Visitors;

using System;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides dependency injection registrations for complex visitors.
/// </summary>
public static partial class IServiceCollectionExtensions
{
    /// <summary>
    /// Registers the complex visitors in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to update.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddComplexVisitors(this IServiceCollection services)
    {
        return services
            .AddSingleton<IVisitor<Complex, string>, Root>()
            .AddSingleton<IVisitor<Complex.Graph.Age, string>, Age>()
            .AddSingleton<IVisitor<Complex.Graph.Children, string>, Children>()
            .AddSingleton<IVisitor<Complex.Graph.Children.Child, string>, ChildrenChild>()
            .AddSingleton<IVisitor<Complex.Graph.Children.Child.Age, string>, ChildrenChildAge>()
            .AddSingleton<IVisitor<Complex.Graph.Children.Child.Name, string>, ChildrenChildName>()
            .AddSingleton<IVisitor<Complex.Graph.Children.Child.Name.Length, string>, ChildrenChildNameLength>()
            .AddSingleton<IVisitor<Complex.Graph.Name, string>, Name>()
            .AddSingleton<IVisitor<Complex.Graph.Name.Length, string>, NameLength>();
    }
}