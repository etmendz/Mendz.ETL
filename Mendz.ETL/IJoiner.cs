using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines a source joiner.
    /// </summary>
    public interface IJoiner
    {
        /// <summary>
        /// Gets or sets the joined sources document specification.
        /// </summary>
        DocumentSpecification JoinedSourcesSpecification { get; set; }

        /// <summary>
        /// Joins inputs from a collection of source adapters.
        /// </summary>
        /// <param name="sources">The source adapters to join.</param>
        /// <returns>The joined inputs.</returns>
        /// <remarks>
        /// A joiner extracts, queries and joins multiple sources to a new mappable input.
        /// Implementations should manage how sources are queried and joined without using up memory.
        /// Note that the joiner is provided a list of source adapters.
        /// It is an option to use a source's Extract() method to read its contents.
        /// Because the sources' SourceDefinitions are available,
        /// it is also an option to skip a source's Extract() method
        /// and perform custom extraction/reading techniques.
        /// Doing so can mean that the extract events may not get triggered,
        /// unless those events are explicitly triggered in the implementation.
        /// The new input should be returned as an enumerable/iterable string.
        /// </remarks>
        IEnumerable<string> Join(List<ISourceAdapter> sources);
    }
}
