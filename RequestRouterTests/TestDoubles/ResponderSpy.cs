namespace RequestRouter.Tests.TestDoubles
{
    using System.Threading.Tasks;

    public class ResponderSpy : ResponderBase
    {
        private readonly StandardResponseBase standardResponse;

        public ResponderSpy()
        {
            this.standardResponse = new StandardResponseStub();
        }

        public ResponderSpy(StandardResponseBase standardResponse)
        {
            this.standardResponse = standardResponse;
        }

        public bool GetResponseCalled { get; private set; }

        protected override async Task<StandardResponseBase> GetResponseAsync(StandardRequestBase standardRequestBase)
        {
            this.GetResponseCalled = true;
            return await Task.FromResult(this.standardResponse);
        }
    }
}
