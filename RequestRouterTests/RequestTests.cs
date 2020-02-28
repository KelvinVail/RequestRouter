using RequestRouter;
using System.Collections.Generic;
using Xunit;

namespace RequestRouterTests
{
    public class RequestTests
    {
        private Request request;

        public RequestTests()
        {
            request = new Request { Id = "123456789", Cost = 123, Friends = new List<string> { "Rita", "Sue", "Bob" }, Name="Gordon Bennett" };
        }
        
        [Fact]
        public void RequestHasAnID()
        {
            var request = new Request();
            Assert.Null(request.Id);
            Assert.Null(request.Name);
            Assert.Equal(0, request.Cost);
            Assert.Null(request.Friends);
        }

        [Fact]
        public void GoldenRequestHasNecessaryFields() {
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
            var golden = request.Convert();
            Assert.IsAssignableFrom<IGoldenRequest>(golden);
        }

        [Fact]
        public void RequestConvertsToAGoldenRequest()
        {
            var goldenRequest = request.Convert();
            Assert.Equal(123, goldenRequest.Value);
            Assert.Equal("Rita", goldenRequest.BestFriend);
            Assert.Equal("Gordon", goldenRequest.FirstName);
            Assert.Equal("Bennett", goldenRequest.LastName);
            Assert.Equal(0, goldenRequest.Age);
            Assert.Equal("123456789", goldenRequest.RequestId);
        }
    }
}
