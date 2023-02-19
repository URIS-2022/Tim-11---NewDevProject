using System.Net;
using System.Runtime.Serialization;

namespace AuctionMS.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : BaseException
    {
        public EntityNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
            this.message = message;
            code = HttpStatusCode.NotFound;
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
