namespace RequestRouterTests
{
    using System.Collections.Generic;
    using RequestRouter;
    using Xunit;

    public class RouterTests
    {
        private readonly Router router = new Router();
        private readonly Request request = new Request();

        [Fact]
        public void GetResponsesReturnsResponses()
        {
            var responses = this.router.GetResponses(this.request);
            Assert.IsAssignableFrom<IEnumerable<Response>>(responses);
        }
    }
}
