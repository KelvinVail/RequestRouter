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

        public IEnumerable<StandardResponseBase> GetResponses(StandardRequestBase standardRequest)
        {
            return this.responders.Select(r => r.Execute(standardRequest));
        }

        public IEnumerable<ResponseBase> GetResponses(RequestBase request)
        {
            if (request is null) return null;

            var standardRequest = request.ToStandard();
            var standardResponse = this.GetResponses(standardRequest);
            return standardResponse.Select(request.FromStandard);
        }
    }
}
