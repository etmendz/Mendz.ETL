using System;
using System.Runtime.Serialization;

namespace Mendz.ETL
{
    /// <summary>
    /// Represents an exception from a joiner.
    /// </summary>
    [Serializable]
    public class ETLJoinerException : Exception
    {
        public ETLJoinerException()
        {
        }

        public ETLJoinerException(string message) 
            : base(message)
        {
        }

        public ETLJoinerException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ETLJoinerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
