namespace RequestRouterTests
{
    using RequestRouter;
    using RequestRouterTests.TestDoubles;
    using Xunit;

    public class ResponderTests
    {
        private readonly ResponderSpy responder = new ResponderSpy();

        [Fact]
        public void GetResponseReturnsResponse()
        {
            var request = new RequestStub();
            var response = this.responder.Execute(request);
            Assert.IsAssignableFrom<Response>(response);
        }

        [Fact]
        public void OnlyRespondToRequestsThatCanBeHandled()
        {
            var invalidRequest = new InvalidRequestStub();
            var response = this.responder.Execute(invalidRequest);
            Assert.Null(response);
        }

        [Fact]
        public void ReturnNullIfRequestIsNull()
        {
            var response = this.responder.Execute(null);
            Assert.Null(response);
        }
    }
}
