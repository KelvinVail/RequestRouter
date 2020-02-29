namespace RequestRouter.Tests.TestDoubles
{
    using System;

    public class ResponderSpy : Responder
    {
        private readonly Response response;

        public ResponderSpy()
        {
            this.response = new ResponseStub();
        }

        public ResponderSpy(Response response)
        {
            this.response = response;
        }

        public bool GetResponseCalled { get; private set; }

        protected override Type ValidRequestType => typeof(RequestStub);

        protected override Response GetResponse(Request request)
        {
            this.GetResponseCalled = true;
            return this.response;
        }
    }
}
