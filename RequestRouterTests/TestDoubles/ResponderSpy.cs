namespace RequestRouterTests.TestDoubles
{
    using RequestRouter;

    public class ResponderSpy : Responder
    {
        private readonly Response response;

        public ResponderSpy(Response response)
        {
            this.response = response;
        }

        public bool GetResponseCalled { get; private set; }

        public override Response GetResponse(RealRequest realRequest)
        {
            this.GetResponseCalled = true;
            return this.response;
        }
    }
}
