namespace RequestRouter
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class RequestHandlerBase
    {
        private readonly IEnumerable<ResponderBase> responders;

        protected RequestHandlerBase(IEnumerable<ResponderBase> responders)
        {
            this.responders = responders;
        }

        public IEnumerable<ResponseBase> GetResponses(RequestBase request)
        {
            if (request is null) return null;

            var standardRequest = this.ToStandard(request);
            standardRequest.LogId = request.LogId;
            var standardResponse = this.GetResponses(standardRequest);
            var responses = standardResponse.Select(this.ToResponse);
            return responses;
        }

        public abstract StandardRequestBase ToStandard(RequestBase request);

        public abstract ResponseBase FromStandard(StandardResponseBase standardResponse);

        private IEnumerable<StandardResponseBase> GetResponses(StandardRequestBase standardRequest)
        {
            return this.responders.Select(r => r.Execute(standardRequest));
        }

        private ResponseBase ToResponse(StandardResponseBase standardResponse)
        {
            var response = this.FromStandard(standardResponse);
            response.ResponderName = standardResponse.ResponderName;
            response.RequestLogId = standardResponse.RequestLogId;
            return response;
        }
    }
}
