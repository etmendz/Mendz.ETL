using System;

namespace Mendz.ETL.Common
{
    /// <summary>
    /// Represents an empty data filter.
    /// </summary>
    public class EmptyDataFilter : IDataFilter<string>
    {
        /// <summary>
        /// Gets or sets a predicate to also evaluate if the data is empty.
        /// </summary>
        public Predicate<string> IsEmpty { get; set; }

        public EmptyDataFilter()
        {
        }

        public EmptyDataFilter(Predicate<string> isEmpty) => IsEmpty = isEmpty;

        /// <summary>
        /// Filters null, empty, white-space or IsEmpty data.
        /// </summary>
        /// <param name="data">The data to evaluate.</param>
        /// <returns>True if data is empty. Otherwise, false.</returns>
        public bool Filter(string data)
        {
            bool filter = false;
            if (IsEmpty != null)
            {
                filter = IsEmpty(data);
            }
            return (string.IsNullOrWhiteSpace(data) || filter);
        }
    }
}
