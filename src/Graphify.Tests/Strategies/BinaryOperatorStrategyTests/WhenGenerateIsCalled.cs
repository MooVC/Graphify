namespace Graphify.Strategies.BinaryOperatorStrategyTests;

using System.Linq;
using Graphify.Model;
using Graphify.Strategies;

public sealed class WhenGenerateIsCalled
{
    [Fact]
    public void GivenNoBinaryOperatorsThenNoSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated = [new Encapsulated { Type = "int", BinaryOperators = [] }];
        var strategy = new BinaryOperatorStrategy();

        // Act
        IEnumerable<Source> result = strategy.Generate(subject);

        // Assert
        result.ShouldBeEmpty();
    }

    [Fact]
    public void GivenBinaryOperatorsThenSourceIsGenerated()
    {
        // Arrange
        Subject subject = TestSubject.Create();
        subject.Encapsulated =
        [
            new Encapsulated
            {
                Type = "int",
                BinaryOperators =
                [
                    new BinaryOperator
                    {
                        IsLeftSubject = true,
                        IsReturnSubject = true,
                        IsRightSubject = true,
                        Left = subject.Qualification,
                        Operator = "op_Addition",
                        Return = subject.Qualification,
                        Right = subject.Qualification,
                        Symbol = "+",
                    },
                    new BinaryOperator
                    {
                        IsLeftSubject = true,
                        IsReturnSubject = true,
                        IsRightSubject = false,
                        Left = subject.Qualification,
                        Operator = "op_Subtraction",
                        Return = subject.Qualification,
                        Right = "int",
                        Symbol = "-",
                    },
                    new BinaryOperator
                    {
                        IsLeftSubject = false,
                        IsReturnSubject = false,
                        IsRightSubject = true,
                        Left = "int",
                        Operator = "op_GreaterThan",
                        Return = "bool",
                        Right = subject.Qualification,
                        Symbol = ">",
                    },
                ],
            },
        ];
        var strategy = new BinaryOperatorStrategy();

        // Act
        Source[] sources = strategy.Generate(subject).ToArray();

        // Assert
        sources.Length.ShouldBe(3);
        sources[0].Hint.ShouldBe("BinaryOperators.00");
        sources[0].Code.ShouldContain("operator +(Sample left, Sample right)");
        sources[0].Code.ShouldContain("new Sample(left._value + right._value)");
        sources[1].Code.ShouldContain("operator -(Sample left, int right)");
        sources[1].Code.ShouldContain("throw new ArgumentNullException(\"left\")");
        sources[2].Code.ShouldContain("operator >(int left, Sample right)");
        sources[2].Code.ShouldContain("return (bool)(left > right._value);");
    }
}