namespace RequestRouter.Tests
{
    using System;
    using Xunit;

    public class RequestTests : RequestBase
    {
        [Fact]
        public void RequestHasGuidLogId()
        {
            Assert.True(Guid.TryParse(this.LogId, out _));
        }
    }
}
