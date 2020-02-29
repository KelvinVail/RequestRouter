namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter.Tests.TestDoubles;
    using Xunit;

    public class RouterTests
    {
        private readonly Router router;
        private readonly RequestStub request = new RequestStub();
        private readonly ResponseStub response = new ResponseStub { ResponseName = "Response" };
        private readonly ResponderSpy responder;
        private readonly ResponseStub responseTwo = new ResponseStub { ResponseName = "ResponseTwo" };

        public RouterTests()
        {
            this.responder = new ResponderSpy(this.response);
            var responderTwo = new ResponderSpy(this.responseTwo);
            var responders = new List<Responder> { this.responder, responderTwo };
            this.router = new Router(responders);
        }

        [Fact]
        public void GetResponsesReturnsResponses()
        {
            var responses = this.router.GetResponses(this.request);
            Assert.IsAssignableFrom<IEnumerable<Response>>(responses);
        }

        [Fact]
        public void OnGetResponsesResponderIsCalled()
        {
            var responses = this.router.GetResponses(this.request);
            Assert.NotEmpty(responses);
            Assert.True(this.responder.GetResponseCalled);
        }

        [Fact]
        public void OnGetResponsesResponderResponseIsReturned()
        {
            var responses = this.router.GetResponses(this.request);
            Assert.Contains(this.response, responses);
        }

        [Fact]
        public void OnGetResponsesMultipleRespondersAreCalled()
        {
            var responses = this.router.GetResponses(this.request).ToList();
            Assert.Contains(this.response, responses);
            Assert.Contains(this.responseTwo, responses);
        }

        [Fact]
        public void OnGetResponsesSubTypePropertiesAreMaintained()
        {
            var responses = this.router.GetResponses(this.request);
            var responseNames = responses.Cast<ResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }
    }
}
