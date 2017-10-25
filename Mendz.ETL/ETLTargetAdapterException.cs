using System;
using System.Runtime.Serialization;

namespace Mendz.ETL
{
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
