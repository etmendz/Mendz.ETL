using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// The base joiner.
    /// </summary>
    public abstract class JoinerBase : IJoiner
    {
        public DocumentSpecification JoinedSourcesSpecification { get; set; }

        public abstract IEnumerable<string> Join(IList<ISourceAdapter> sources);
    }
}
