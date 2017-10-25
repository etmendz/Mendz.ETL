using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// The base joiner.
    /// </summary>
    public abstract class JoinerBase : IJoiner
    {
        public DocumentSpecification JoinedSourcesSpecification { get; set; }

        public abstract IEnumerable<string> Join(List<ISourceAdapter> sources);

        DocumentSpecification IJoiner.JoinedSourcesSpecification
        {
            get => JoinedSourcesSpecification;
            set => JoinedSourcesSpecification = value;
        }

        IEnumerable<string> IJoiner.Join(List<ISourceAdapter> sources) => Join(sources);
    }
}
