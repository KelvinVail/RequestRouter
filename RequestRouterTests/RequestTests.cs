using RequestRouter;
using Xunit;

namespace RequestRouterTests
{
    public class RequestTests
    {
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
        public void GoldenRequestHasRequestId()
        {
            Assert.NotNull(typeof(IGoldenRequest).GetProperty("RequestId"));
        }

        [Fact]
        public void RequestHasConvertMethod()
        {
            var request = new Request();
            request.Convert();
        }

        [Fact]
        public void RequestConvertReturnsAnIGolden()
        {
            var request = new Request();
            var golden = request.Convert();
            Assert.IsAssignableFrom<IGoldenRequest>(golden);
        }
    }
}
