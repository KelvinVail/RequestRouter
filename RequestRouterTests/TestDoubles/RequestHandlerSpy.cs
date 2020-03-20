namespace RequestRouter.Tests.TestDoubles
{
    using System.Collections.Generic;

    public class RequestHandlerSpy : RequestHandlerBase
    {
        public RequestHandlerSpy(IEnumerable<ResponderBase> responders)
            : base(responders)
        {
        }

        public bool ConvertedToStandard { get; set; }

        public override StandardRequestBase ToStandard(RequestBase request)
        {
            this.ConvertedToStandard = true;
            return new StandardRequestStub();
        }

        public override ResponseBase FromStandard(StandardResponseBase standardResponse)
        {
            var stub = (StandardResponseStub)standardResponse;
            return new ResponseStub { ResponseName = stub?.ResponseName };
        }
    }
}
