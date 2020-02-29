namespace RequestRouterTests
{
    using RequestRouter;
    using Xunit;

    public class ResponderTests
    {
        [Fact]
        public void GetResponseReturnsResponse()
        {
            var responder = new Responder();
            var request = new RealRequest();
            var response = responder.GetResponse(request);
            Assert.IsType<Response>(response);
        }
    }
}
