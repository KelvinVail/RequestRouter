namespace RequestRouter.ProductTwo
{
    using System.Collections.Generic;

    public class StandardHandler : RequestHandlerBase
    {
        public StandardHandler(IEnumerable<ResponderBase> responders)
            : base(responders)
        {
        }

        public override StandardRequestBase ToStandard(RequestBase request)
        {
            return (StandardRequest)request;
        }

        public override ResponseBase FromStandard(StandardResponseBase standardResponse)
        {
            return (StandardResponse)standardResponse;
        }
    }
}
