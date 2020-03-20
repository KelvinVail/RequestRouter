namespace RequestRouter.ProductOne
{
    using System.Threading.Tasks;

    public sealed class ResponderOne : ResponderBase
    {
        protected override async Task<StandardResponseBase> GetResponseAsync(StandardRequestBase request)
        {
            // Convert StandardRequest to structure expected by this responder
            var standardRequest = (StandardRequest)request;

            //// Call the responder

            //// Convert response from this responder to StandardResponse

            return await Task.FromResult(ToStandardResponse(standardRequest));
        }

        private static StandardResponse ToStandardResponse(StandardRequest standardRequest)
        {
            return new StandardResponse
            {
                RequestId = standardRequest.Id,
            };
        }
    }
}
