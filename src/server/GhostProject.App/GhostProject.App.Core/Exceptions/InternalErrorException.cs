using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GhostProject.App.Core.Exceptions
{
    public class InternalErrorException : BusinessException
    {
        public IDictionary<string, IEnumerable<string>> Errors { get; }
        
        public InternalErrorException()
        {
        }

        public InternalErrorException(string message, IDictionary<string, IEnumerable<string>> errors) : base(message)
        {
            Errors = errors;
        }

        public InternalErrorException(string message) : base(message)
        {
        }

        public InternalErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
