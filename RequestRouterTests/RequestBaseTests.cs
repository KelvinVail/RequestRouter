namespace RequestRouter.Tests
{
    using System;
    using Xunit;

    public class RequestBaseTests : RequestBase
    {
        [Fact]
        public void RequestHasGuidLogId()
        {
            Assert.True(Guid.TryParse(this.LogId, out _));
        }
    }
}
