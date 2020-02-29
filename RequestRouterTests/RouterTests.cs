﻿namespace RequestRouterTests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter;
    using RequestRouterTests.TestDoubles;
    using Xunit;

    public class RouterTests
    {
        private readonly Router router;
        private readonly RealRequest _realRequest = new RealRequest();
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
            var responses = this.router.GetResponses(this._realRequest);
            Assert.IsAssignableFrom<IEnumerable<Response>>(responses);
        }

        [Fact]
        public void OnGetResponsesResponderIsCalled()
        {
            var responses = this.router.GetResponses(this._realRequest);
            Assert.NotEmpty(responses);
            Assert.True(this.responder.GetResponseCalled);
        }

        [Fact]
        public void OnGetResponsesResponderResponseIsReturned()
        {
            var responses = this.router.GetResponses(this._realRequest);
            Assert.Contains(this.response, responses);
        }

        [Fact]
        public void OnGetResponsesMultipleRespondersAreCalled()
        {
            var responses = this.router.GetResponses(this._realRequest).ToList();
            Assert.Contains(this.response, responses);
            Assert.Contains(this.responseTwo, responses);
        }

        [Fact]
        public void OnGetResponsesSubTypePropertiesAreMaintained()
        {
            var responses = this.router.GetResponses(this._realRequest);
            var responseNames = responses.Cast<ResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }
    }
}
