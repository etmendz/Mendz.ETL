using System;
using System.Runtime.Serialization;

namespace Mendz.ETL
{
    /// <summary>
    /// Represents an exception from a target adapter.
    /// </summary>
    [Serializable]
    public class ETLTargetAdapterException : Exception
    {
        public ETLTargetAdapterException()
        {
        }

        public ETLTargetAdapterException(string message) 
            : base(message)
        {
        }

        public ETLTargetAdapterException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ETLTargetAdapterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
