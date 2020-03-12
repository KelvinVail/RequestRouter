namespace RequestRouter.ProductOne
{
    public sealed class ResponderOne : ResponderBase
    {
        protected override StandardResponseBase GetResponse(StandardRequestBase request)
        {
            var standardRequest = (StandardRequest)request;
            //// Convert StandardRequest to structure expected by this responder

            //// Call the responder

            //// Convert response from this responder to StandardResponse

            return ToStandardResponse(standardRequest);
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
