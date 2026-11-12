namespace Graphify.Model
{
    /// <summary>
    /// Describes an enclosing graph node.
    /// </summary>
    internal sealed class Predecessor
    {
        private Predecessor(string declaration, string name)
        {
            Declaration = declaration;
            Name = name;
        }

        public string Declaration { get; }

        public string Name { get; }

        public static Predecessor From(Element element, string declaration)
        {
            return new Predecessor(declaration, element.Name);
        }

        public static Predecessor From(Property property)
        {
            return new Predecessor(property.Declaration, property.Name);
        }
    }
}