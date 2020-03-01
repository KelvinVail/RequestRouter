namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter.Tests.TestDoubles;
    using Xunit;

    public class ResponderTests
    {
        private readonly Router router;
        private readonly ResponderSpy responder = new ResponderSpy();
        private readonly RequestStub request = new RequestStub();

        public ResponderTests()
        {
            this.router = new Router(new List<ResponderBase> { this.responder });
        }

        [Fact]
        public void GetResponseReturnsResponse()
        {
            var responses = this.router.GetResponses(this.request);
            Assert.IsAssignableFrom<ResponseBase>(responses.FirstOrDefault());
        }

        [Fact]
        public void OnlyRespondToRequestsThatCanBeHandled()
        {
            var invalidRequest = new InvalidRequestStub();
            var response = this.router.GetResponses(invalidRequest).First();
            Assert.Null(response);
        }

        [Fact]
        public void ReturnNullIfRequestIsNull()
        {
            var response = this.router.GetResponses(null).First();
            Assert.Null(response);
        }

        [Fact]
        public void ResponseContainsRequestId()
        {
            var response = this.router.GetResponses(this.request).First();
            Assert.Equal(this.request.Id, response.RequestId);
        }

        [Fact]
        public void ResponseContainsResponderName()
        {
            var response = this.router.GetResponses(this.request).First();
            Assert.Equal(this.responder.GetType().Name, response.ResponderName);
        }
    }
}
