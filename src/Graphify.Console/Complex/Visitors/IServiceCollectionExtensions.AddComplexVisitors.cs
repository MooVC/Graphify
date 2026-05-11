namespace Graphify.Console.Complex.Visitors;

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
            .AddSingleton<IComplexVisitor<Complex.Graph.Age, string>, Age>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Children, string>, Children>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Children.Child, string>, ChildrenChild>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Children.Child.Age, string>, ChildrenChildAge>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Children.Child.Name, string>, ChildrenChildName>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Children.Child.Name.Length, string>, ChildrenChildNameLength>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Name, string>, Name>()
            .AddSingleton<IComplexVisitor<Complex.Graph.Name.Length, string>, NameLength>();
    }
}