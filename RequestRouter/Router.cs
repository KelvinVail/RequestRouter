namespace RequestRouter
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Router
    {
        private readonly IEnumerable<ResponderBase> responders;

        public Router(IEnumerable<ResponderBase> responders)
        {
            this.responders = responders;
        }

        public IEnumerable<ResponseBase> GetResponses(RequestBase requestBase)
        {
            return this.responders.Select(r => r.Execute(requestBase));
        }
    }
}
