namespace RequestRouter.ProductOne.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using RequestRouter.ProductOne.Responders;
    using Xunit;

    public class ProductOneTests
    {
        private readonly Router router;

        public ProductOneTests()
        {
            this.router = new Router(new List<Responder> { new ResponderOne() });
        }

        [Fact]
        public void ResponderOneInheritsResponder()
        {
            var responderOne = new ResponderOne();
            Assert.IsAssignableFrom<Responder>(responderOne);
        }

        [Fact]
        public void GoldenResponseInheritsResponse()
        {
            var response = new GoldenResponse();
            Assert.IsAssignableFrom<Response>(response);
        }

        [Fact]
        public void ResponderOneAcceptsGoldenRequest()
        {
            var request = new GoldenRequest();
            var response = this.router.GetResponses(request).First();
            Assert.IsType<GoldenResponse>(response);
        }
    }
}
