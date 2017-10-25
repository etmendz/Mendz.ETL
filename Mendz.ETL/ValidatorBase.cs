using System;

namespace Mendz.ETL
{
    /// <summary>
    /// The base validator.
    /// </summary>
    public abstract class ValidatorBase : IValidator
    {
        public event ETLValidatorEventHandler OnValidating;
        public event ETLValidatorEventHandler OnValidated;

        public bool IsThrowValidationException { get; set; }

        public virtual bool Validate(DocumentSpecification documentSpecification)
        {
            bool isOK = true;
            if (documentSpecification.IsValidate)
            {
                ETLValidatorEventArgs e = new ETLValidatorEventArgs()
                {
                    DocumentSpecification = documentSpecification
                };
                OnValidating?.Invoke(this, e);
                try
                {
                    isOK = ValidateDocument(documentSpecification);
                }
                catch (Exception exception)
                {
                    if (IsThrowValidationException)
                    {
                        throw exception;
                    }
                    else
                    {
                        e.Exception = exception;
                        isOK = false;
                    }
                }
                OnValidated?.Invoke(this, e);
            }
            return isOK;
        }

        /// <summary>
        /// Validates a document.
        /// </summary>
        /// <param name="documentSpecification">The document specification.</param>
        /// <returns>True if validation is passed. Otherwise, false.</returns>
        protected abstract bool ValidateDocument(DocumentSpecification documentSpecification);

        bool IValidator.IsThrowValidationException
        {
            get => IsThrowValidationException;
            set => IsThrowValidationException = value;
        }

        bool IValidator.Validate(DocumentSpecification documentSpecification) => Validate(documentSpecification);
    }
}
