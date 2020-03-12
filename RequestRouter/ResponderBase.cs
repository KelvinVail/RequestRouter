namespace RequestRouter
{
    public abstract class ResponderBase
    {
        internal StandardResponseBase Execute(StandardRequestBase standardRequest)
        {
            var response = this.GetResponse(standardRequest);
            response.RequestLogId = standardRequest.LogId;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract StandardResponseBase GetResponse(StandardRequestBase standardRequest);
    }
}
