using System;
using System.Runtime.Serialization;

namespace Mendz.ETL
{
    /// <summary>
    /// Represents an exception from a mapper.
    /// </summary>
    [Serializable]
    public class ETLMapperException : Exception
    {
        public ETLMapperException()
        {
        }

        public ETLMapperException(string message) 
            : base(message)
        {
        }

        public ETLMapperException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ETLMapperException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
