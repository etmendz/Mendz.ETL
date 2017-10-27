using System.Collections.Generic;

namespace Mendz.ETL
{
    /// <summary>
    /// Defines an ETL mapper.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Raised when the mapper starts.
        /// </summary>
        event ETLMapperEventHandler OnMapperStart;

        /// <summary>
        /// Raised before the input is transformed to an output.
        /// This event can be used to perform pre-mapping operations on the input.
        /// </summary>
        event ETLMapperEventHandler OnTransforming;

        /// <summary>
        /// Raised after the input is transformed to an output.
        /// This event can be used to perform post-mapping operations on the output.
        /// </summary>
        event ETLMapperEventHandler OnTransformed;

        /// <summary>
        /// Raised when the mapper ends.
        /// </summary>
        event ETLMapperEventHandler OnMapperEnd;

        /// <summary>
        /// Maps the input to an output.
        /// </summary>
        /// <param name="input">The input to map.</param>
        /// <param name="sourceSpecification">The source's document specification.</param>
        /// <param name="targetSpecification">The target's document specification.</param>
        /// <returns>The mapped output.</returns>
        IEnumerable<string> Transform(IEnumerable<string> input, DocumentSpecification sourceSpecification, DocumentSpecification targetSpecification);
    }
}
