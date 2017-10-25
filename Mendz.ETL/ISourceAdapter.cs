using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines a source that extracts input.
    /// </summary>
    public interface ISourceAdapter
    {
        /// <summary>
        /// Raised when the source adapter starts.
        /// Use this event to perform pre-extraction operations on the source before validation.
        /// For example, this event can be used to save an Excel file to CSV or XML.
        /// </summary>
        event ETLSourceAdapterEventHandler OnSourceAdapterStart;

        /// <summary>
        /// Raised before the source is extracted.
        /// This event is raised before the source is opened or read.
        /// Use this event to perform pre-extraction operations on the validated source.
        /// </summary>
        event ETLSourceAdapterEventHandler OnExtracting;

        /// <summary>
        /// Raised when an input is extracted from the source.
        /// The input at this point can be as raw as it can be from the source.
        /// This event can be used to perform post-extraction operations on an input.
        /// For example, this event can be used to log or keep track of some raw infos/values from the input.
        /// </summary>
        event ETLSourceAdapterEventHandler OnExtracted;

        /// <summary>
        /// Raised when the source adapter ends.
        /// </summary>
        event ETLSourceAdapterEventHandler OnSourceAdapterEnd;

        /// <summary>
        /// Gets or sets the source's document specification.
        /// </summary>
        DocumentSpecification SourceSpecification { get; set; }

        /// <summary>
        /// Gets or sets the source validator.
        /// </summary>
        IValidator SourceValidator { get; set; }

        /// <summary>
        /// Extracts inputs from the source.
        /// </summary>
        /// <returns>Enumerable/iterable inputs.</returns>
        /// <remarks>
        /// <para>
        /// The return value is enumerable/iterable to support streaming extractions.
        /// For example, a text file can be read and yielded per line.
        /// Another example, an XML file can be read and yielded per fragment.
        /// </para>
        /// <para>
        /// Note that the extraction can be implemented as non-streaming.
        /// For example, a text or XML file can be read and returned in full
        /// (wrapped in an enumerable/iterable type).
        /// </para>
        /// </remarks>
        IEnumerable<string> Extract();
    }
}
