using System;

namespace Mendz.ETL
{
    public delegate void ETLSourceAdapterEventHandler(ISourceAdapter source, ETLSourceAdapterEventArgs e);
    public class ETLSourceAdapterEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the source document specification.
        /// </summary>
        public DocumentSpecification SourceSpecification { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        public string Input { get; set; }
    }

    public delegate void ETLMapperEventHandler(IMapper mapper, ETLMapperEventArgs e);
    public class ETLMapperEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the source document specification.
        /// </summary>
        public DocumentSpecification SourceSpecification { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the target document specification.
        /// </summary>
        public DocumentSpecification TargetSpecification { get; set; }
    }

    public delegate void ETLTargetAdapterEventHandler(ITargetAdapter target, ETLTargetAdapterEventArgs e);
    public class ETLTargetAdapterEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the output.
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or sets the target document specification.
        /// </summary>
        public DocumentSpecification TargetSpecification { get; set; }
    }

    public delegate void ETLValidatorEventHandler(IValidator validator, ETLValidatorEventArgs e);
    public class ETLValidatorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the document specification.
        /// </summary>
        public DocumentSpecification DocumentSpecification { get; set; }

        /// <summary>
        /// Gets or sets the exception thrown by the validation for the event handler.
        /// </summary>
        public Exception Exception { get; set; }
    }
}
