namespace RequestRouter.ProductCyber.Tests
{
    using RequestRouter;
    using RequestRouter.ProductCyber.Responders;
    using Xunit;
    public class ACMEResponderTests: ACMEResponder
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
        public void ResponderGetResponseReturnsAStandardResponse()
        {
            var standardRequest = new StandardRequest();
            var response = GetResponse(standardRequest);
            Assert.IsAssignableFrom<StandardResponseBase>(response);
        }

        protected override StandardResponseBase GetResponse(StandardRequestBase standardRequest)
        {
            return base.GetResponse(standardRequest);
        }
    }
}
