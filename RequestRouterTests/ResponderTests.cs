namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter.Tests.TestDoubles;
    using Xunit;

    public class ResponderTests
    {
        private readonly RequestHandlerSpy requestHandler;
        private readonly ResponderSpy responder = new ResponderSpy();
        private readonly RequestStub request = new RequestStub();

        public ResponderTests()
        {
            this.requestHandler = new RequestHandlerSpy(new List<ResponderBase> { this.responder });
        }

        [Fact]
        public void GetResponseReturnsResponse()
        {
            var responses = this.requestHandler.GetResponses(this.request);
            Assert.IsAssignableFrom<ResponseBase>(responses.FirstOrDefault());
        }

        [Fact]
        public void ReturnNullIfRequestIsNull()
        {
            var response = this.requestHandler.GetResponses(null);
            Assert.Null(response);
        }

        [Fact]
        public void ResponseContainsRequestId()
        {
            var response = this.requestHandler.GetResponses(this.request).First();
            Assert.Equal(this.request.LogId, response.RequestLogId);
        }

        [Fact]
        public void ResponseContainsResponderName()
        {
            var response = this.requestHandler.GetResponses(this.request).First();
            Assert.Equal(this.responder.GetType().Name, response.ResponderName);
        }
    }
}
