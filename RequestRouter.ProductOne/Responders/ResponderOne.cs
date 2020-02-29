namespace RequestRouter.ProductOne.Responders
{
    using System;

    public sealed class ResponderOne : Responder
    {
        protected override Type ValidRequestType => typeof(GoldenRequest);

        protected override Response GetResponse(Request request)
        {
            //// TODO Convert GoldenRequest to structure expected by this responder

            //// TODO Call the responder

            //// TODO Convert response from this responder to GoldenResponse

            return new GoldenResponse();
        }
    }
}
