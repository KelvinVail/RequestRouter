namespace RequestRouter.ProductOne
{
    using System;

    public sealed class ResponderOne : ResponderBase
    {
        protected override Type ValidRequestType => typeof(StandardRequest);

        protected override StandardResponseBase GetResponse(StandardRequestBase standardRequestBase)
        {
            var standardRequest = (StandardRequest)standardRequestBase;
            //// Convert StandardRequest to structure expected by this responder

            //// Call the responder

            //// Convert response from this responder to StandardResponse

            return ToStandardResponse(standardRequest);
        }

        private static StandardResponse ToStandardResponse(StandardRequest standardRequest)
        {
            return new StandardResponse
            {
                Id = "ResponseId",
                RequestId = standardRequest.Id,
            };
        }
    }
}
