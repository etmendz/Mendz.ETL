using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines a target the loads output.
    /// </summary>
    public interface ITargetAdapter
    {
        /// <summary>
        /// Raised when the target adapter starts.
        /// </summary>
        event ETLTargetAdapterEventHandler OnTargetAdapterStart;

        /// <summary>
        /// Raised before the output is loaded to the target.
        /// This event can be used to perform pre-loading operations on an ouput.
        /// For example, this event can be used to apply final cleanup/touches to the output.
        /// </summary>
        event ETLTargetAdapterEventHandler OnLoading;

        /// <summary>
        /// Raised after the output is loaded to the target.
        /// This event can be used to perform post-loading operations on an ouput.
        /// For example, this event can be used to commit logs about the output.
        /// </summary>
        event ETLTargetAdapterEventHandler OnLoaded;

        /// <summary>
        /// Raised when the target adapter ends.
        /// This event can be used to perform post-loading operations on the target.
        /// For example, this event can be used to clean-up.
        /// </summary>
        event ETLTargetAdapterEventHandler OnTargetAdapterEnd;

        /// <summary>
        /// Gets or sets the target's document specification.
        /// </summary>
        DocumentSpecification TargetSpecification { get; set; }

        /// <summary>
        /// Gets or sets the target validator.
        /// </summary>
        IValidator TargetValidator { get; set; }

        /// <summary>
        /// Loads outputs to the target.
        /// </summary>
        /// <param name="output">Enumerable/iterable outputs.</param>
        /// <remarks>
        /// <para>
        /// The parameter is enumerable/iterable to support streaming loads.
        /// For example, a text file can be passed line per line.
        /// Another example, an XML file can be passed a fragment at a time.
        /// </para>
        /// <para>
        /// Note that the loading can be implemented as non-streaming.
        /// For example, a text or XML file can be passed in full
        /// (wrapped in an enumerable/iterable type).
        /// </para>
        /// </remarks>
        void Load(IEnumerable<string> output);
    }
}
