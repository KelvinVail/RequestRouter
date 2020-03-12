namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter.Tests.TestDoubles;
    using Xunit;

    public class RouterTests
    {
        private readonly RequestHandlerSpy requestHandler;
        private readonly RequestStub request = new RequestStub();
        private readonly ResponderSpy responder;

        public RouterTests()
        {
            this.responder = new ResponderSpy(new StandardResponseStub { ResponseName = "Response" });
            var responderTwo = new ResponderSpy(new StandardResponseStub { ResponseName = "ResponseTwo" });
            var responders = new List<ResponderBase> { this.responder, responderTwo };
            this.requestHandler = new RequestHandlerSpy(responders);
        }

        [Fact]
        public void GetResponsesReturnsResponses()
        {
            var responses = this.requestHandler.GetResponses(this.request);
            Assert.IsAssignableFrom<IEnumerable<ResponseBase>>(responses);
        }

        [Fact]
        public void OnGetResponsesResponderIsCalled()
        {
            var responses = this.requestHandler.GetResponses(this.request);
            Assert.NotEmpty(responses);
            Assert.True(this.responder.GetResponseCalled);
        }

        [Fact]
        public void OnGetResponsesMultipleResponsesCanBeReturned()
        {
            var responses = this.requestHandler.GetResponses(this.request).ToList();
            Assert.True(responses.Count > 1);
        }

        [Fact]
        public void OnGetResponsesSubTypePropertiesAreMaintained()
        {
            var responses = this.requestHandler.GetResponses(this.request);
            var responseNames = responses.Cast<ResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }

        [Fact]
        public void GetResponsesAcceptsABespokeRequest()
        {
            var bespokeRequest = new RequestStub();
            var responses = this.requestHandler.GetResponses(bespokeRequest);
            Assert.IsAssignableFrom<IEnumerable<ResponseBase>>(responses);
        }

        [Fact]
        public void WhenRequestIsBespokeItIsConvertedToStandard()
        {
            var bespokeRequest = new RequestStub();
            this.requestHandler.GetResponses(bespokeRequest);
            Assert.True(this.requestHandler.ConvertedToStandard);
        }

        [Fact]
        public void WhenRequestIsNullReturnNull()
        {
            var responses = this.requestHandler.GetResponses(null);
            Assert.Null(responses);
        }

        [Fact]
        public void WhenRequestIsBespokeResponderResponseIsReturned()
        {
            var bespokeRequest = new RequestStub();
            var responses = this.requestHandler.GetResponses(bespokeRequest);
            var responseNames = responses.Cast<ResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }
    }
}
