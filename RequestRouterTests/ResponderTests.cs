namespace RequestRouterTests
{
    using RequestRouter;
    using RequestRouterTests.TestDoubles;
    using Xunit;

    public class ResponderTests
    {
        private readonly ResponderSpy responder = new ResponderSpy();
        private readonly RequestStub request = new RequestStub();

        [Fact]
        public void GetResponseReturnsResponse()
        {
            var response = this.responder.Execute(this.request);
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

        [Fact]
        public void ResponseContainsRequestId()
        {
            var response = this.responder.Execute(this.request);
            Assert.Equal(this.request.Id, response.RequestId);
        }

        [Fact]
        public void ResponseContainsResponderName()
        {
            var response = this.responder.Execute(this.request);
            Assert.Equal(this.responder.GetType().Name, response.ResponderName);
        }
    }
}
