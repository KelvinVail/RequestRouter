namespace RequestRouter.ProductOne
{
    using System;

    public sealed class ResponderOne : ResponderBase
    {
        protected override Type ValidRequestType => typeof(StandardRequest);

        protected override ResponseBase GetResponse(RequestBase requestBase)
        {
            var standardRequest = (StandardRequest)requestBase;
            //// Convert StandardRequest to structure expected by this responder

            //// Call the responder

            //// Convert response from this responder to StandardResponse

            return ToStandardResponse(standardRequest);
        }

        private static StandardResponse ToStandardResponse(StandardRequest request)
        {
            return new StandardResponse
            {
                Id = "ResponseId",
                RequestId = request.Id,
            };
        }
    }
}
