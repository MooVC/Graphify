namespace Graphify.Syntax
{
    using Graphify.Model;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;

    internal static partial class SubjectExtensions
    {
        /// <summary>
        /// Constructs the visitor interface type for a subject.
        /// </summary>
        /// <param name="subject">The subject that declares the visitor interface.</param>
        /// <param name="instance">The symbol for the visitor's node type argument.</param>
        /// <param name="result">The symbol for the visitor's result type argument.</param>
        /// <returns>The qualified visitor interface with both type arguments.</returns>
        public static Symbol ToObserverType(this Subject subject, Symbol instance, Symbol result)
        {
            string name = $"{InterfaceNamePrefix}{subject.Name}{VisitorTypeSuffix}";

            return subject.Qualify(name).ToSymbol().WithArguments(instance, result);
        }
    }
}