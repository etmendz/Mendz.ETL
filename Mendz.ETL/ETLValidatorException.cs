using System;
using System.Runtime.Serialization;

namespace Mendz.ETL
{
    /// <summary>
    /// Represents an exception from a validator.
    /// </summary>
    [Serializable]
    public class ETLValidatorException : Exception
    {
        public ETLValidatorException()
        {
        }

        public ETLValidatorException(string message) 
            : base(message)
        {
        }

        public ETLValidatorException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ETLValidatorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
