namespace RequestRouter.ProductOne
{
    using System.Collections.Generic;

    public class RequestOneHandler : RequestHandlerBase
    {
        public RequestOneHandler(IEnumerable<ResponderBase> responders)
            : base(responders)
        {
        }

        public override StandardRequestBase ToStandard(RequestBase request)
        {
            return new StandardRequest { Id = "RequestId" };
        }

        public override ResponseBase FromStandard(StandardResponseBase standardResponse)
        {
            var standard = (StandardResponse)standardResponse;
            return new ResponseOne { RequestId = standard.RequestId, Id = "ResponseId" };
        }
    }
}
