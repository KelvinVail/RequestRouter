namespace RequestRouter.Tests
{
    using System;
    using Xunit;

    public class RequestTests : Request
    {
        [Fact]
        public void RequestHasGuidId()
        {
            Assert.True(Guid.TryParse(this.Id, out _));
        }
    }
}
