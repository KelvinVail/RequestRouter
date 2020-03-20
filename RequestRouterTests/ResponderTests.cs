namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
        public async Task GetResponseReturnsResponse()
        {
            var responses = await this.requestHandler.GetResponsesAsync(this.request);
            Assert.IsAssignableFrom<ResponseBase>(responses.FirstOrDefault());
        }

        [Fact]
        public async Task ReturnNullIfRequestIsNull()
        {
            var response = await this.requestHandler.GetResponsesAsync(null);
            Assert.Null(response);
        }

        [Fact]
        public async Task ResponseContainsRequestId()
        {
            var response = await this.requestHandler.GetResponsesAsync(this.request);
            Assert.Equal(this.request.LogId, response.First().RequestLogId);
        }

        [Fact]
        public async Task ResponseContainsResponderName()
        {
            var response = await this.requestHandler.GetResponsesAsync(this.request);
            Assert.Equal(this.responder.GetType().Name, response.First().ResponderName);
        }
    }
}
