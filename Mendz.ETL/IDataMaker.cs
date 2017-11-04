namespace Mendz.ETL
{
    /// <summary>
    /// Defines a data maker.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    /// <remarks>
    /// Implementations can create/"inject" data in to the ETL flow
    /// where the source may or may not necessarily be an ETL ingredient.
    /// Typical usage can be to inject headers, footers, digital/electronic signatures,
    /// sub-totals, grand totals, formatting/layout elements, page/section breakers, etc.
    /// It can also be used to "inject" data that may affect the ETL flow or the data itself
    /// in adapters, joiners, mappers, event handlers or custom "routers".
    /// Note that Mendz.ETL.IData* implementations can also share data with each other.
    /// </remarks>
    public interface IDataMaker<T>
    {
        /// <summary>
        /// Makes data that can be used in the ETL flow.
        /// </summary>
        /// <param name="data">Optional data parameters.</param>
        /// <returns>Data that can be used in the ETL flow.</returns>
        T Make(params object[] data);
    }
}
