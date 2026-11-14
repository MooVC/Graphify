namespace Graphify.Syntax
{
    using MooVC.Syntax.CSharp;

    /// <summary>
    /// Provides extensions for composing type references and constraints in generated declarations.
    /// </summary>
    internal static partial class SymbolExtensions
    {
        /// <summary>
        /// Constructs the graph interface type for a subject.
        /// </summary>
        /// <param name="subject">The symbol for the graph's root type.</param>
        /// <returns>The <c>IGraph&lt;TSubject&gt;</c> type with <paramref name="subject"/> as its type argument.</returns>
        public static Symbol ToGraph(this Symbol subject)
        {
            return ((Symbol)(Name: "IGraph", Qualifier: "Graphify")).WithArguments(subject);
        }
    }
}