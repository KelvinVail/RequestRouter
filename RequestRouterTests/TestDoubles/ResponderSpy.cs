namespace RequestRouter.Tests.TestDoubles
{
    using System;

    public class ResponderSpy : ResponderBase
    {
        private readonly ResponseBase response;

        public ResponderSpy()
        {
            this.response = new ResponseStub();
        }

        public ResponderSpy(ResponseBase response)
        {
            this.response = response;
        }

        public bool GetResponseCalled { get; private set; }

        protected override Type ValidRequestType => typeof(RequestStub);

        protected override ResponseBase GetResponse(RequestBase requestBase)
        {
            this.GetResponseCalled = true;
            return this.response;
        }
    }
}
