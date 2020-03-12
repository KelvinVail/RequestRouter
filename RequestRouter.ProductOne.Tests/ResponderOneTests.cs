namespace RequestRouter.ProductOne.Tests
{
    using System.Collections.Generic;
    using System.Linq;
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
        public void ResponderOneAcceptsRequest()
        {
            var request = GetRequestExample();
            var response = this.requestHandler.GetResponses(request).First();
            Assert.IsAssignableFrom<ResponseBase>(response);
        }

        [Fact]
        public void ResponseContainsResponderName()
        {
            var request = GetRequestExample();
            var response = this.requestHandler.GetResponses(request).First();
            Assert.Equal("ResponderOne", response.ResponderName);
        }

        [Fact]
        public void RequestIdCanBeSet()
        {
            var request = GetRequestExample();
            Assert.Equal("RequestId", request.Id);
        }

        [Fact]
        public void ResponseContainsRequestId()
        {
            var request = GetRequestExample();
            var response = this.requestHandler.GetResponses(request).Cast<ResponseOne>().First();
            Assert.Equal("RequestId", response.RequestId);
        }

        [Fact]
        public void ResponseContainsAnId()
        {
            var request = GetRequestExample();
            var response = this.requestHandler.GetResponses(request).Cast<ResponseOne>().First();
            Assert.Equal("ResponseId", response.Id);
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
