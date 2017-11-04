namespace Mendz.ETL.Common
{
    /// <summary>
    /// Represents a pass through mapper.
    /// </summary>
    public class PassThroughMapper : MapperBase
    {
        /// <summary>
        /// Returns the input as-is as output.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="sourceSpecification">The source specification.</param>
        /// <param name="targetSpecification">The target specification.</param>
        /// <returns>The input returned as-is as output.</returns>
        protected override string TransformInputToOutput(string input, 
            DocumentSpecification sourceSpecification, 
            DocumentSpecification targetSpecification) => input;
    }
}
