namespace Graphify.Syntax
{
    using Graphify.Model;
    using MooVC.Syntax.CSharp;
    using static Graphify.Names;

    internal static partial class SubjectExtensions
    {
        /// <summary>
        /// Creates the sealed navigator class declaration for a subject.
        /// </summary>
        /// <param name="subject">The subject that supplies the navigator's name and accessibility.</param>
        /// <returns>The navigator class declaration.</returns>
        public static Class ToNavigatorClass(this Subject subject)
        {
            return Class.Undefined.Named(GetNavigatorName(subject.Name))
                .WithScope(subject.Accessibility.ToScope())
                .WithExtensibility(Modifiers.Sealed);
        }
    }
}