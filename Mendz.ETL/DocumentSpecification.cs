using System.Dynamic;

namespace Mendz.ETL
{
    /// <summary>
    /// Stores the document specification and details.
    /// </summary>
    public class DocumentSpecification
    {
        /// <summary>
        /// Gets or sets the document specification name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the document address or path.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the document name pattern.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the document format name (ex, delimited, positional, xml, etc.)
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the document layout/schema name.
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the document layout/schema version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the document layout/shema definition path.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Gets or sets an indicator if validation should be performed.
        /// </summary>
        public bool IsValidate { get; set; }

        /// <summary>
        /// Gets or sets implementation specific details. 
        /// </summary>
        public dynamic Details { get; set; } = new ExpandoObject();
    }
}
