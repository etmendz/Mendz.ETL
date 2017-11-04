using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines a data splitter.
    /// </summary>
    /// <remarks>
    /// <para>
    /// IDataSplitter splits a data stream to a collection of data streams.
    /// This collection of data streams can be used as input or output in the ETL flow.
    /// </para>
    /// <para>
    /// Ideal for defining data manipulations/processes that may apply
    /// regardless if the data is input or output in the ETL flow.
    /// Mendz.ETL.IData* implementations can also share data with each other.
    /// For example, in an IDataSplitter-IDataJoiner tandem,
    /// the IDataSplitter can be the producer and the IDataJoiner can be the consumer,
    /// or perhaps the other way around...
    /// </para>
    /// </remarks>
    public interface IDataSplitter
    {
        /// <summary>
        /// Splits a stream of data to a collection of enumerable/iterable data.
        /// </summary>
        /// <param name="data">The enumerable/iterable data.</param>
        /// <returns>The collection of enumerable/iterable data.</returns>
        IList<IEnumerable<string>> Split(IEnumerable<string> data);
    }
}
