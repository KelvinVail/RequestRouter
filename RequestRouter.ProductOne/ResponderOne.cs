namespace RequestRouter.ProductOne
{
    using System;

    public sealed class ResponderOne : ResponderBase
    {
        protected override Type ValidRequestType => typeof(GoldenRequest);

        protected override ResponseBase GetResponse(RequestBase requestBase)
        {
            //// TODO Convert GoldenBaseRequest to structure expected by this responder

            //// TODO Call the responder

            //// TODO Convert _baseResponse from this responder to GoldenBaseResponse

            return new GoldenResponse();
        }
    }
}
