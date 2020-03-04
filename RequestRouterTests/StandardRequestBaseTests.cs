namespace RequestRouter.Tests
{
    using System;
    using Xunit;

    public class StandardRequestBaseTests : StandardRequestBase
    {
        [Fact]
        public void RequestHasGuidLogId()
        {
            Assert.True(Guid.TryParse(this.LogId, out _));
        }
    }
}
