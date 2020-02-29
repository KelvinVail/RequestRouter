namespace RequestRouterTests
{
    using System;
    using RequestRouter;
    using Xunit;

    public class RequestTests : Request
    {
        [Fact]
        public void RequestHasGuidId()
        {
            Assert.True(Guid.TryParse(Id, out _));
        }
    }
}
