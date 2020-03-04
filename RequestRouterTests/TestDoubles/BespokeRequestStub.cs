namespace RequestRouter.Tests.TestDoubles
{
    public class BespokeRequestStub : RequestBase
    {
        public bool ConvertedToStandard { get; set; }

        public override StandardRequestBase ToStandard()
        {
            this.ConvertedToStandard = true;
            return new StandardRequestStub();
        }

        public override ResponseBase FromStandard(StandardResponseBase standardResponse)
        {
            if (standardResponse is null) return null;
            var stub = (StandardResponseStub)standardResponse;
            return new BespokeResponseStub { ResponseName = stub.ResponseName };
        }
    }
}
