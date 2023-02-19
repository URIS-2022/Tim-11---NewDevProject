namespace AuctionMS.Exceptions
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    [Serializable]
    public class BaseException : Exception
    {
        public string message { get; set; }

        public HttpStatusCode code { get; set; }

        public override string Message
        {
            get { return this.message; }
        }

        public BaseException(string message, HttpStatusCode code)
        {
            this.message = message;
            this.code = code;
        }

        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
