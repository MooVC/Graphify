namespace Graphify.Console;

using System;
using Graphify.Console.Complex;
using Graphify.Console.Complex.Visitors;
using Graphify.Console.Simple;
using Graphify.Console.Simple.Visitors;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

/// <summary>
/// Entry point for the application, which is used to facilitate debugging of the Graphify project.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Entry point for the application, which is used to facilitate debugging of the Graphify project.
    /// </summary>
    public static async Task Main()
    {
        WriteLine("Test Application for Graphify");

        var services = new ServiceCollection();

        _ = services
            .AddSimpleVisitors()
            .AddSimpleNavigator()
            .AddComplexVisitors()
            .AddComplexNavigator();

        IServiceProvider provider = services.BuildServiceProvider();

        var simple = new Simple.Simple
        {
            Age = 85,
            Name = "Patrick Stewart",
        };

        var complex = new Complex.Complex
        {
            Age = 77,
            Children =
            [
                new Child
                {
                    Age = 50,
                    Name = "Ayana Brooks",
                },
                new Child
                {
                    Age = 48,
                    Name = "Asante Brooks",
                },
                new Child
                {
                    Age = 46,
                    Name = "Cabral Brooks",
                },
            ],
            Name = "Avery Brooks",
        };

        await Enumerate(simple, provider);
        await Enumerate(complex, provider);

        _ = ReadLine();
    }

    private static async Task Enumerate<T>(T instance, IServiceProvider provider)
        where T : class
    {
        INavigator<T> navigator = provider.GetRequiredService<INavigator<T>>();

        await foreach (string item in navigator.Navigate<string>(instance, CancellationToken.None))
        {
            WriteLine(item);
        }
    }
}