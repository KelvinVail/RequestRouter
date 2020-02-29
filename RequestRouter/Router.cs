namespace RequestRouter
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Router
    {
        private readonly IEnumerable<Responder> responders;

        public Router(IEnumerable<Responder> responders)
        {
            this.responders = responders;
        }

        public IEnumerable<Response> GetResponses(RealRequest realRequest)
        {
            return this.responders.Select(r => r.GetResponse(realRequest));
        }
    }
}
