using System;
using System.Runtime.Serialization;

namespace Application.Services.Auths
{
    [Serializable]
    internal class UnAuthorizeActiveException : Exception
    {
        public UnAuthorizeActiveException()
        {
        }

        public UnAuthorizeActiveException(string message) : base(message)
        {
        }

        public UnAuthorizeActiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnAuthorizeActiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}