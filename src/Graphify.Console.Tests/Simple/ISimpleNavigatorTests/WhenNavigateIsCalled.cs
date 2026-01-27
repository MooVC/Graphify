namespace Graphify.Console.Simple.ISimpleNavigatorTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Graphify.Console.Simple;
using Graphify.Console.Simple.Visitors;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenNavigateIsCalled
{
    [Fact]
    public async Task GivenSimpleInstanceThenAllVisitorsAreObserved()
    {
        // Arrange
        const int age = 85;
        const bool isAdult = true;
        const string name = "Patrick Stewart";
        const int nameLength = 15;

        var services = new ServiceCollection();

        _ = services
            .AddSimpleVisitors()
            .AddSimpleNavigator();

        var provider = services.BuildServiceProvider();
        var navigator = provider.GetRequiredService<ISimpleNavigator>();
        var simple = new Simple
        {
            Age = age,
            Name = name,
        };

        string[] expectedObservations =
        [
            $"Simple: {name}",
            $"Simple.Graph.Age: {age}",
            $"Simple.Graph.IsAdult: {isAdult}",
            $"Simple.Graph.Name: {name}",
            $"Simple.Graph.Name.Length: {nameLength}",
        ];

        // Act
        var observations = new List<string>();

        await foreach (string observation in navigator.Navigate<string>(simple, CancellationToken.None))
        {
            observations.Add(observation);
        }

        // Assert
        observations.OrderBy(value => value, StringComparer.Ordinal)
            .ShouldBe(expectedObservations.OrderBy(value => value, StringComparer.Ordinal));
    }
}