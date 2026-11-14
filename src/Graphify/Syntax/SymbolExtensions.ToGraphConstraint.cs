namespace Graphify.Syntax
{
    using MooVC.Syntax.CSharp;

    internal static partial class SymbolExtensions
    {
        /// <summary>
        /// Creates a generic constraint for a reference type that implements the subject's graph interface.
        /// </summary>
        /// <param name="subject">The symbol for the graph's root type.</param>
        /// <returns>A constraint requiring <c>class</c> and <c>IGraph&lt;TSubject&gt;</c>.</returns>
        public static Constraint ToGraphConstraint(this Symbol subject)
        {
            return Constraint.Unspecified.WithNature(Natures.Class)
                .WithInterfaces(Implementation.Unspecified
                    .Named((Name: "IGraph", Qualifier: "Graphify"))
                    .WithArguments((Token)subject));
        }
    }
}