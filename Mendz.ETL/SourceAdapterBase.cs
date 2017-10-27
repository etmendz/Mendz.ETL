using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// The base source adapter.
    /// </summary>
    public abstract class SourceAdapterBase : ISourceAdapter
    {
        public event ETLSourceAdapterEventHandler OnSourceAdapterStart;
        public event ETLSourceAdapterEventHandler OnExtracting;
        public event ETLSourceAdapterEventHandler OnExtracted;
        public event ETLSourceAdapterEventHandler OnSourceAdapterEnd;

        public DocumentSpecification SourceSpecification { get; set; }

        public virtual IValidator SourceValidator { get; set; }

        public virtual IEnumerable<string> Extract()
        {
            ETLSourceAdapterEventArgs e = new ETLSourceAdapterEventArgs()
            {
                SourceSpecification = SourceSpecification
            };
            OnSourceAdapterStart?.Invoke(this, e);
            if (SourceValidator != null)
            {
                e.IsValid = SourceValidator.Validate(SourceSpecification);
            }
            if (e.IsValid)
            {
                OnExtracting?.Invoke(this, e);
                foreach (var item in ExtractInput())
                {
                    e.Input = item;
                    OnExtracted?.Invoke(this, e);
                    yield return e.Input;
                }
            }
            OnSourceAdapterEnd?.Invoke(this, e);
        }

        /// <summary>
        /// Extracts the input from the source.
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
        /// wrapped in an enumerable/iterable type.
        /// </para>
        /// </remarks>
        protected abstract IEnumerable<string> ExtractInput();

        DocumentSpecification ISourceAdapter.SourceSpecification
        {
            get => SourceSpecification;
            set => SourceSpecification = value;
        }

        IValidator ISourceAdapter.SourceValidator
        {
            get => SourceValidator;
            set => SourceValidator = value;
        }

        IEnumerable<string> ISourceAdapter.Extract() => Extract();
    }
}
