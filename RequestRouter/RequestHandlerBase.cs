namespace RequestRouter
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class RequestHandlerBase
    {
        private readonly IEnumerable<ResponderBase> responders;

        protected RequestHandlerBase(IEnumerable<ResponderBase> responders)
        {
            this.responders = responders;
        }

        public async Task<IEnumerable<ResponseBase>> GetResponsesAsync(RequestBase request)
        {
            if (request is null) return null;

            var standardRequest = this.ToStandard(request);
            standardRequest.LogId = request.LogId;
            var standardResponse = await this.GetResponsesAsync(standardRequest);
            var responses = standardResponse.Select(this.ToResponse);
            return responses;
        }

        public abstract StandardRequestBase ToStandard(RequestBase request);

        public abstract ResponseBase FromStandard(StandardResponseBase standardResponse);

        private async Task<IEnumerable<StandardResponseBase>> GetResponsesAsync(StandardRequestBase standardRequest)
        {
            return await Task.WhenAll(this.responders.Select(async r => await r.ExecuteAsync(standardRequest)));
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
