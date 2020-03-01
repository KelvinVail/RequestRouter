namespace RequestRouter.ProductOne.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class ResponderOneTests
    {
        private readonly Router router;

        public ResponderOneTests()
        {
            this.router = new Router(new List<ResponderBase> { new ResponderOne() });
        }

        [Fact]
        public void StandardResponseInheritsResponseBase()
        {
            var response = new StandardResponse();
            Assert.IsAssignableFrom<ResponseBase>(response);
        }

        [Fact]
        public void StandardRequestInheritsRequestBase()
        {
            var request = new StandardRequest();
            Assert.IsAssignableFrom<RequestBase>(request);
        }

        [Fact]
        public void ResponderOneInheritsResponderBase()
        {
            var responderOne = new ResponderOne();
            Assert.IsAssignableFrom<ResponderBase>(responderOne);
        }

        [Fact]
        public void ResponderOneAcceptsStandardRequest()
        {
            var request = new StandardRequest();
            var response = this.router.GetResponses(request).First();
            Assert.IsType<StandardResponse>(response);
        }

        [Fact]
        public void ResponseContainsResponderName()
        {
            var request = GetStandardRequestExample();
            var response = this.router.GetResponses(request).First();
            Assert.Equal("ResponderOne", response.ResponderName);
        }

        [Fact]
        public void ResponseContainsRequestId()
        {
            var request = GetStandardRequestExample();
            var response = (StandardResponse)this.router.GetResponses(request).First();
            Assert.Equal("RequestId", response.RequestId);
        }

        [Fact]
        public void ResponseContainsAnId()
        {
            var request = GetStandardRequestExample();
            var response = (StandardResponse)this.router.GetResponses(request).First();
            Assert.Equal("ResponseId", response.Id);
        }

        private static StandardRequest GetStandardRequestExample()
        {
            return new StandardRequest
            {
                Id = "RequestId",
            };
        }
    }
}
