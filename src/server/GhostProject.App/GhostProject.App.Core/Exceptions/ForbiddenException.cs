using System;
using System.Runtime.Serialization;

namespace GhostProject.App.Core.Exceptions
{
    public class ForbiddenException : BusinessException
    {
        public ForbiddenException()
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }

        public ForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
