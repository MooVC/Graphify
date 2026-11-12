namespace Graphify.Model
{
    using System.Collections.Immutable;

    /// <summary>
    /// A property or collection element at a specific path through the subject's graph.
    /// </summary>
    internal sealed class Node
    {
        private Node(Property property, Element element, ImmutableArray<Predecessor> ancestors, string parentPath, string parentMethod)
        {
            Property = property;
            Element = element;
            Ancestors = ancestors;
            ParentPath = parentPath;
            Method = string.Concat(parentMethod, Name);
        }

        public ImmutableArray<Predecessor> Ancestors { get; }

        public Element Element { get; }

        public string Method { get; }

        public string Name => Element?.Name ?? Property.Name;

        public string ParentPath { get; }

        public Property Property { get; }

        public int Tier => Ancestors.Length + 1;

        public string Type => Element?.Type ?? Property.Type;

        public static ImmutableArray<Node> Create(ImmutableArray<Property> properties, byte depth)
        {
            var nodes = ImmutableArray.CreateBuilder<Node>();
            AddProperties(nodes, properties, ImmutableArray<Predecessor>.Empty, string.Empty, string.Empty, depth);
            return nodes.ToImmutable();
        }

        private static void AddProperties(
            ImmutableArray<Node>.Builder nodes,
            ImmutableArray<Property> properties,
            ImmutableArray<Predecessor> ancestors,
            string path,
            string method,
            byte depth)
        {
            if (ancestors.Length >= depth)
            {
                return;
            }

            foreach (Property property in properties)
            {
                var node = new Node(property, null, ancestors, path, method);
                nodes.Add(node);

                ImmutableArray<Predecessor> parents = ancestors.Add(Predecessor.From(property));
                string propertyPath = string.IsNullOrEmpty(path) ? node.Name : string.Concat(path, ".", node.Name);

                if (property.Element is Element element)
                {
                    var elementNode = new Node(property, element, parents, propertyPath, node.Method);
                    nodes.Add(elementNode);

                    AddProperties(
                        nodes,
                        element.Properties,
                        parents.Add(Predecessor.From(element, property.Declaration)),
                        string.Concat(propertyPath, ".", elementNode.Name),
                        elementNode.Method,
                        depth);
                }

                AddProperties(nodes, property.Properties, parents, propertyPath, node.Method, depth);
            }
        }
    }
}