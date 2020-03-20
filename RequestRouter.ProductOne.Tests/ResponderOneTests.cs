namespace RequestRouter.ProductOne.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ResponderOneTests
    {
        private readonly RequestOneHandler requestHandler;

        public ResponderOneTests()
        {
            this.requestHandler = new RequestOneHandler(new List<ResponderBase> { new ResponderOne() });
        }

        [Fact]
        public void StandardResponseInheritsResponseBase()
        {
            var response = new StandardResponse();
            Assert.IsAssignableFrom<StandardResponseBase>(response);
        }

        [Fact]
        public void StandardRequestInheritsRequestBase()
        {
            var request = new StandardRequest();
            Assert.IsAssignableFrom<StandardRequestBase>(request);
        }

        [Fact]
        public void ResponderOneInheritsResponderBase()
        {
            var responderOne = new ResponderOne();
            Assert.IsAssignableFrom<ResponderBase>(responderOne);
        }

        [Fact]
        public async Task ResponderOneAcceptsRequest()
        {
            var request = GetRequestExample();
            var response = await this.requestHandler.GetResponsesAsync(request);
            Assert.IsAssignableFrom<ResponseBase>(response.First());
        }

        [Fact]
        public async Task ResponseContainsResponderName()
        {
            var request = GetRequestExample();
            var response = await this.requestHandler.GetResponsesAsync(request);
            Assert.Equal("ResponderOne", response.First().ResponderName);
        }

        [Fact]
        public void RequestIdCanBeSet()
        {
            var request = GetRequestExample();
            Assert.Equal("RequestId", request.Id);
        }

        [Fact]
        public async Task ResponseContainsRequestId()
        {
            var request = GetRequestExample();
            var response = await this.requestHandler.GetResponsesAsync(request);
            Assert.Equal("RequestId", response.Cast<ResponseOne>().First().RequestId);
        }

        [Fact]
        public async Task ResponseContainsAnId()
        {
            var request = GetRequestExample();
            var response = await this.requestHandler.GetResponsesAsync(request);
            Assert.Equal("ResponseId", response.Cast<ResponseOne>().First().Id);
        }

        private static RequestOne GetRequestExample()
        {
            return new RequestOne()
            {
                Id = "RequestId",
            };
        }
    }
}
