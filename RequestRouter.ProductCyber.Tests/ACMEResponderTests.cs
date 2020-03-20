namespace RequestRouter.ProductCyber.Tests
{
    using System.Threading.Tasks;
    using RequestRouter;
    using RequestRouter.ProductCyber.Responders;
    using Xunit;

    public class ACMEResponderTests : ACMEResponder
    {
        [Fact]
        public void ResponderExistsAndIsResponderBase()
        {
            var acmeResponder = new ACMEResponder();
            Assert.IsAssignableFrom<ResponderBase>(acmeResponder);
        }

        [Fact]
        public void ResponseExistsAndIsResponseBase()
        {
            var response = new ACMEResponse();
            Assert.IsAssignableFrom<ResponseBase>(response);
        }

        [Fact]
        public async Task ResponderGetResponseReturnsAStandardResponse()
        {
            var standardRequest = new StandardRequest();
            var response = await this.GetResponseAsync(standardRequest);
            Assert.IsAssignableFrom<StandardResponseBase>(response);
        }
    }
}
