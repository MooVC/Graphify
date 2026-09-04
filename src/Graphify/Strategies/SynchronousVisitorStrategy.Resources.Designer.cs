namespace Graphify.Strategies
{
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [GeneratedCode("Manual", "1.0.0.0")]
    [DebuggerNonUserCode]
    [CompilerGenerated]
    /// <summary>
    /// Provides strongly typed resources for <see cref="SynchronousVisitorStrategy"/>.
    /// </summary>
    internal class SynchronousVisitorStrategy_Resources
    {
        private static ResourceManager resourceManager;
        private static CultureInfo resourceCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="SynchronousVisitorStrategy_Resources"/> class.
        /// </summary>
        internal SynchronousVisitorStrategy_Resources()
        {
        }

        /// <summary>
        /// Gets the cached resource manager instance.
        /// </summary>
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (resourceManager == null)
                {
                    resourceManager = new ResourceManager("Graphify.Strategies.SynchronousVisitorStrategy.Resources", typeof(SynchronousVisitorStrategy_Resources).Assembly);
                }

                return resourceManager;
            }
        }

        /// <summary>
        /// Gets or sets the culture used for resource lookups.
        /// </summary>
        internal static CultureInfo Culture
        {
            get => resourceCulture;
            set => resourceCulture = value;
        }

        /// <summary>
        /// Gets the generated visitor interface content.
        /// </summary>
        internal static string GenerateContent => ResourceManager.GetString("GenerateContent", resourceCulture);
    }
}