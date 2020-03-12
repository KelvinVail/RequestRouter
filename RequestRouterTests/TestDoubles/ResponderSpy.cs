namespace RequestRouter.Tests.TestDoubles
{
    using System;

    public class ResponderSpy : ResponderBase
    {
        private readonly StandardResponseBase standardResponse;

        public ResponderSpy()
        {
            this.standardResponse = new StandardResponseStub();
        }

        public ResponderSpy(StandardResponseBase standardResponse)
        {
            this.standardResponse = standardResponse;
        }

        public bool GetResponseCalled { get; private set; }

        protected override StandardResponseBase GetResponse(StandardRequestBase standardRequestBase)
        {
            this.GetResponseCalled = true;
            return this.standardResponse;
        }
    }
}
