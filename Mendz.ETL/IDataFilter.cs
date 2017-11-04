using System;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines a data filter.
    /// </summary>
    /// <typeparam name="T">The type of data.</typeparam>
    public interface IDataFilter<T>
    {
        /// <summary>
        /// Determines if data can be filtered or not in the ETL flow.
        /// Note that actual data handling will be decided/performed by the caller.
        /// </summary>
        /// <param name="data">The data to evaluate.</param>
        /// <returns>Returns an indicator that the caller can use to handle the data in the ETl flow.</returns>
        bool Filter(T data);
    }
}
