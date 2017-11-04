using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines a data joiner.
    /// </summary>
    /// <remarks>
    /// <para>
    /// IDataJoiner joins a collection of data streams in to a single stream of data.
    /// This new stream of data can be used as input or output in the ETL flow.
    /// </para>
    /// <para>
    /// It is easy to imagine using IDataJoiner in IJoiner implementations.
    /// However, it can also be used in adapters, joiners, mappers, event handlers and custom "routers"
    /// where multiple/various input and/or output data can be aggregated, collated or joined.
    /// Mendz.ETL.IData* implementations can also share data with each other.
    /// For example, in an IDataSplitter-IDataJoiner tandem,
    /// the IDataSplitter can be the producer and the IDataJoiner can be the consumer,
    /// or perhaps the other way around...
    /// </para>
    /// </remarks>
    public interface IDataJoiner
    {
        /// <summary>
        /// Joins a collection of data.
        /// </summary>
        /// <param name="data">The collection of enumerable/iterable data.</param>
        /// <returns>The joined data.</returns>
        /// <remarks>
        /// Unlike IJoiner.Join() which expects source adapters as parameter,
        /// thus limiting it to working on input data,
        /// IDataJoiner.Join() expects a collection of enumerable/iterable data,
        /// making it ideal for defining data manipulations/processes that may apply
        /// regardless if the data is input or output in the ETL flow.
        /// </remarks>
        IEnumerable<string> Join(IList<IEnumerable<string>> data);
    }
}
