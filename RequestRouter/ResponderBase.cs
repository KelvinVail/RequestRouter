namespace RequestRouter
{
    using System.Threading.Tasks;

    public abstract class ResponderBase
    {
        internal async Task<StandardResponseBase> ExecuteAsync(StandardRequestBase standardRequest)
        {
            var response = await this.GetResponseAsync(standardRequest);
            response.RequestLogId = standardRequest.LogId;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract Task<StandardResponseBase> GetResponseAsync(StandardRequestBase standardRequest);
    }
}
