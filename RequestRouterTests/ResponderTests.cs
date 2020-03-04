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
        private readonly StandardRequestStub standardRequest = new StandardRequestStub();

        public ResponderTests()
        {
            this.router = new Router(new List<ResponderBase> { this.responder });
        }

        [Fact]
        public void GetResponseReturnsResponse()
        {
            var responses = this.router.GetResponses(this.standardRequest);
            Assert.IsAssignableFrom<StandardResponseBase>(responses.FirstOrDefault());
        }

        [Fact]
        public void OnlyRespondToRequestsThatCanBeHandled()
        {
            var invalidRequest = new InvalidStandardRequestStub();
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
            var response = this.router.GetResponses(this.standardRequest).First();
            Assert.Equal(this.standardRequest.LogId, response.RequestLogId);
        }

        [Fact]
        public void ResponseContainsResponderName()
        {
            var response = this.router.GetResponses(this.standardRequest).First();
            Assert.Equal(this.responder.GetType().Name, response.ResponderName);
        }
    }
}
