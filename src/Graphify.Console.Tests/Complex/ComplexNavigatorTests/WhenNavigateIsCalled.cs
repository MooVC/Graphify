namespace Graphify.Console.Complex.ComplexNavigatorTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Graphify.Console.Complex;
using Graphify.Console.Complex.Visitors;
using Microsoft.Extensions.DependencyInjection;

public sealed class WhenNavigateIsCalled
{
    [Fact]
    public async Task GivenComplexInstanceThenAllVisitorsAreObserved()
    {
        // Arrange
        const int age = 77;
        const int childCount = 3;
        const int childAgeFirst = 50;
        const int childAgeSecond = 48;
        const int childAgeThird = 46;
        const string name = "Avery Brooks";
        const int nameLength = 12;
        const string childNameFirst = "Ayana Brooks";
        const int childNameLengthFirst = 12;
        const string childNameSecond = "Asante Brooks";
        const int childNameLengthSecond = 13;
        const string childNameThird = "Cabral Brooks";
        const int childNameLengthThird = 13;

        var services = new ServiceCollection();

        _ = services
            .AddComplexVisitors()
            .AddComplexNavigator();

        ServiceProvider provider = services.BuildServiceProvider();
        IComplexNavigator navigator = provider.GetRequiredService<IComplexNavigator>();

        var complex = new Complex
        {
            Age = age,
            Children =
            [
                new Child
                {
                    Age = childAgeFirst,
                    Name = childNameFirst,
                },
                new Child
                {
                    Age = childAgeSecond,
                    Name = childNameSecond,
                },
                new Child
                {
                    Age = childAgeThird,
                    Name = childNameThird,
                },
            ],
            Name = name,
        };

        string[] expectedObservations =
        [
            $"Complex: {name}",
            $"Complex.Graph.Age: {age}",
            $"Complex.Graph.Children: {childCount}",
            $"Complex.Graph.Children.Child: {childNameFirst}",
            $"Complex.Graph.Children.Child: {childNameSecond}",
            $"Complex.Graph.Children.Child: {childNameThird}",
            $"Complex.Graph.Children.Child.Age: {childAgeFirst}",
            $"Complex.Graph.Children.Child.Age: {childAgeSecond}",
            $"Complex.Graph.Children.Child.Age: {childAgeThird}",
            $"Complex.Graph.Children.Child.Name: {childNameFirst}",
            $"Complex.Graph.Children.Child.Name: {childNameSecond}",
            $"Complex.Graph.Children.Child.Name: {childNameThird}",
            $"Complex.Graph.Children.Child.Name.Length: {childNameLengthFirst}",
            $"Complex.Graph.Children.Child.Name.Length: {childNameLengthSecond}",
            $"Complex.Graph.Children.Child.Name.Length: {childNameLengthThird}",
            $"Complex.Graph.Name: {name}",
            $"Complex.Graph.Name.Length: {nameLength}",
        ];

        // Act
        var observations = new List<string>();

        await foreach (string observation in navigator.Navigate<string>(complex, CancellationToken.None))
        {
            observations.Add(observation);
        }

        // Assert
        observations
            .OrderBy(value => value, StringComparer.Ordinal)
            .ShouldBe(expectedObservations.OrderBy(value => value, StringComparer.Ordinal));
    }
}