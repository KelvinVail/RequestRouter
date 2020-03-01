namespace RequestRouter.Tests
{
    using System;
    using Xunit;

    public class RequestBaseTests : RequestBase
    {
        [Fact]
        public void RequestHasGuidId()
        {
            Assert.True(Guid.TryParse(this.Id, out _));
        }
    }
}
