namespace RequestRouter.ProductOne.Tests
{
    using Xunit;

    public class RealRequestTests
    {
        private readonly RealRequest request;

        public RealRequestTests()
        {
            this.request = new RealRequest { Id = "123456789", Cost = 123, Friends = { "Rita", "Sue", "Bob" }, Name = "Gordon Bennett" };
        }

        [Fact]
        public void GoldenRequestHasNecessaryFields()
        {
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("RequestId"));
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("Value"));
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("BestFriend"));
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("FirstName"));
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("LastName"));
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("Age"));
        }

        [Fact]
        public void RequestConvertReturnsAnIGolden()
        {
            var golden = this.request.Convert();
            Assert.IsAssignableFrom<IGoldenRequest>(golden);
        }

        [Fact]
        public void RequestConvertsToAGoldenRequest()
        {
            var goldenRequest = this.request.Convert();
            Assert.Equal(123, goldenRequest.Value);
            Assert.Equal("Rita", goldenRequest.BestFriend);
            Assert.Equal("Gordon", goldenRequest.FirstName);
            Assert.Equal("Bennett", goldenRequest.LastName);
            Assert.Equal(0, goldenRequest.Age);
            Assert.Equal("123456789", goldenRequest.RequestId);
        }

        [Fact]
        public void GoldenRequestHasConvertToAgentRequestMethod()
        {
            Assert.NotNull(typeof(IGoldenRequest).GetMethod("ConvertToAgentRequest"));
        }

        [Fact]
        public void AgentOneRequestHasNecessaryFields()
        {
            Assert.NotNull(typeof(AgentOneRequest).GetProperty("BrokerName"));
            Assert.NotNull(typeof(AgentOneRequest).GetProperty("RequestedCost"));
            Assert.NotNull(typeof(AgentOneRequest).GetProperty("NumFriends"));
        }
    }
}
