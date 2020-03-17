namespace RequestRouter.ProductCyber.Tests
{
    using Xunit;
    public class SmashingBrokerRequestTests
    {
        [Fact]
        public void Exists() {
            var req = new SmashingBrokerRequest();
        }

        [Fact]
        public void SmashingBrokerRequestImplementsRequestBase()
        {
            var req = new SmashingBrokerRequest();
            Assert.IsAssignableFrom<RequestBase>(req);
        }

    }
}
