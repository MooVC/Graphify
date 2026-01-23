namespace Graphify.Console.Complex.Visitors;

using System;
using Microsoft.Extensions.DependencyInjection;

public static partial class IServiceCollectionExtensions
{
    public static IServiceCollection AddComplexVisitors(this IServiceCollection services)
    {
        return services
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