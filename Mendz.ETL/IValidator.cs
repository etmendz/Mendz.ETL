namespace Mendz.ETL
{
    /// <summary>
    /// Defines a validator.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Raised when validating a document.
        /// </summary>
        event ETLValidatorEventHandler OnValidating;

        /// <summary>
        /// Raised after validating a document.
        /// </summary>
        event ETLValidatorEventHandler OnValidated;

        /// <summary>
        /// Gets or sets whether validation exceptions are thrown or suppressed.
        /// </summary>
        bool IsThrowValidationException { get; set; }

        /// <summary>
        /// When implemented, checks if the document specification's IsValidate is true.
        /// If so, validates the source/target document.
        /// Otherwise, the document can be assumed passing validation.
        /// </summary>
        /// <param name="documentSpecification">The document specification.</param>
        /// <returns>
        /// True if validation is passed. Otherwise, false.
        /// If the document specification's IsValidate is false,
        /// or if no validation is performed,
        /// this method must return true.
        /// </returns>
        bool Validate(DocumentSpecification documentSpecification);
    }
}
