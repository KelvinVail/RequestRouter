namespace RequestRouter
{
    using System;

    public abstract class ResponderBase
    {
        protected abstract Type ValidRequestType { get; }

        internal StandardResponseBase Execute(StandardRequestBase standardRequest)
        {
            if (standardRequest == null) return null;
            if (!this.CanExecute(standardRequest)) return null;

            var response = this.GetResponse(standardRequest);
            response.RequestLogId = standardRequest.LogId;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract StandardResponseBase GetResponse(StandardRequestBase standardRequest);

        private bool CanExecute(StandardRequestBase standardRequest)
        {
            return standardRequest.GetType() == this.ValidRequestType;
        }
    }
}
