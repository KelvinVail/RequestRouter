namespace RequestRouter.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
        public async Task GetResponsesReturnsResponses()
        {
            var responses = await this.requestHandler.GetResponsesAsync(this.request);
            Assert.IsAssignableFrom<IEnumerable<ResponseBase>>(responses);
        }

        [Fact]
        public async Task OnGetResponsesResponderIsCalled()
        {
            var responses = await this.requestHandler.GetResponsesAsync(this.request);
            Assert.NotEmpty(responses);
            Assert.True(this.responder.GetResponseCalled);
        }

        [Fact]
        public async Task OnGetResponsesMultipleResponsesCanBeReturned()
        {
            var responses = await this.requestHandler.GetResponsesAsync(this.request);
            Assert.True(responses.ToList().Count > 1);
        }

        [Fact]
        public async Task OnGetResponsesSubTypePropertiesAreMaintained()
        {
            var responses = await this.requestHandler.GetResponsesAsync(this.request);
            var responseNames = responses.Cast<ResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }

        [Fact]
        public async Task GetResponsesAcceptsABespokeRequest()
        {
            var bespokeRequest = new RequestStub();
            var responses = await this.requestHandler.GetResponsesAsync(bespokeRequest);
            Assert.IsAssignableFrom<IEnumerable<ResponseBase>>(responses);
        }

        [Fact]
        public async Task WhenRequestIsBespokeItIsConvertedToStandard()
        {
            var bespokeRequest = new RequestStub();
            await this.requestHandler.GetResponsesAsync(bespokeRequest);
            Assert.True(this.requestHandler.ConvertedToStandard);
        }

        [Fact]
        public async Task WhenRequestIsNullReturnNull()
        {
            var responses = await this.requestHandler.GetResponsesAsync(null);
            Assert.Null(responses);
        }

        [Fact]
        public async Task WhenRequestIsBespokeResponderResponseIsReturned()
        {
            var bespokeRequest = new RequestStub();
            var responses = await this.requestHandler.GetResponsesAsync(bespokeRequest);
            var responseNames = responses.Cast<ResponseStub>().Select(r => r.ResponseName).ToList();
            Assert.Contains("Response", responseNames);
            Assert.Contains("ResponseTwo", responseNames);
        }
    }
}
