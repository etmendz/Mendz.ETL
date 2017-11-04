using System;
using System.Runtime.Serialization;

namespace Mendz.ETL
{
    /// <summary>
    /// Represents an exception from a source adapter.
    /// </summary>
    [Serializable]
    public class ETLSourceAdapterException : Exception
    {
        public ETLSourceAdapterException()
        {
        }

        public ETLSourceAdapterException(string message) 
            : base(message)
        {
        }

        public ETLSourceAdapterException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ETLSourceAdapterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
