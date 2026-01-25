namespace Graphify.Console.Simple.Visitors;

using System;
using Microsoft.Extensions.DependencyInjection;

public static partial class IServiceCollectionExtensions
{
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