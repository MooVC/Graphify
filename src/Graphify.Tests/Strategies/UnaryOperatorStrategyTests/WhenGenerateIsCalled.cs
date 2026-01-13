namespace Graphify.Strategies.UnaryOperatorStrategyTests;

using System.Linq;
using Graphify.Model;
using Graphify.Strategies;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenNoUnaryOperatorsThenNoSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { Type = "int", UnaryOperators = [] }];
        var strategy = new UnaryOperatorStrategy();

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUnaryOperatorsThenSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated =
        [
            new Encapsulated
            {
                Type = "int",
                UnaryOperators =
                [
                    new UnaryOperator
                    {
                        IsReturnSubject = true,
                        Operator = "op_UnaryNegation",
                        Return = subject.Qualification,
                        Symbol = "-",
                    },
                    new UnaryOperator
                    {
                        IsReturnSubject = true,
                        Operator = "op_Increment",
                        Return = subject.Qualification,
                        Symbol = "++",
                    },
                    new UnaryOperator
                    {
                        IsReturnSubject = false,
                        Operator = "op_True",
                        Return = "bool",
                        Symbol = "true",
                    },
                ],
            },
        ];
        var strategy = new UnaryOperatorStrategy();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(3);
        sources[0].Hint.ShouldBe("UnaryOperators.00");
        sources[0].Code.ShouldContain("operator -");
        sources[0].Code.ShouldContain("new Sample(-subject._value)");
        sources[1].Code.ShouldContain("value = subject._value;");
        sources[1].Code.ShouldContain("new Sample(++value)");
        sources[2].Code.ShouldContain("operator true");
        sources[2].Code.ShouldContain("return (bool)subject._value ? true : false;");
    }
}