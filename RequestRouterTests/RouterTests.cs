﻿namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter.Tests.TestDoubles;
    using Xunit;

    public class RouterTests
    {
        private readonly Router router;
        private readonly StandardRequestStub standardRequest = new StandardRequestStub();
        private readonly StandardResponseStub standardResponse = new StandardResponseStub { ResponseName = "Response" };
        private readonly ResponderSpy responder;
        private readonly StandardResponseStub responseTwo = new StandardResponseStub { ResponseName = "ResponseTwo" };

        public RouterTests()
        {
            this.responder = new ResponderSpy(this.standardResponse);
            var responderTwo = new ResponderSpy(this.responseTwo);
            var responders = new List<ResponderBase> { this.responder, responderTwo };
            this.router = new Router(responders);
        }

        [Fact]
        public void GetResponsesReturnsResponses()
        {
            var responses = this.router.GetResponses(this.standardRequest);
            Assert.IsAssignableFrom<IEnumerable<StandardResponseBase>>(responses);
        }

        [Fact]
        public void OnGetResponsesResponderIsCalled()
        {
            var responses = this.router.GetResponses(this.standardRequest);
            Assert.NotEmpty(responses);
            Assert.True(this.responder.GetResponseCalled);
        }

        [Fact]
        public void OnGetResponsesResponderResponseIsReturned()
        {
            var responses = this.router.GetResponses(this.standardRequest);
            Assert.Contains(this.standardResponse, responses);
        }

        [Fact]
        public void OnGetResponsesMultipleRespondersAreCalled()
        {
            var responses = this.router.GetResponses(this.standardRequest).ToList();
            Assert.Contains(this.standardResponse, responses);
            Assert.Contains(this.responseTwo, responses);
        }

        [Fact]
        public void OnGetResponsesSubTypePropertiesAreMaintained()
        {
            var responses = this.router.GetResponses(this.standardRequest);
            var responseNames = responses.Cast<StandardResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }
    }
}
