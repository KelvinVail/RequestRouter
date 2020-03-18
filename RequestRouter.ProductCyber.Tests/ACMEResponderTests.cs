namespace RequestRouter.ProductCyber.Tests
{
    using RequestRouter.ProductCyber.Responders;
    using Xunit;
    public class ACMEResponderTests
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



    }
}
