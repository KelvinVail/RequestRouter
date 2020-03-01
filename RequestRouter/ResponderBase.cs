namespace RequestRouter
{
    using System;

    public abstract class ResponderBase
    {
        protected abstract Type ValidRequestType { get; }

        internal ResponseBase Execute(RequestBase requestBase)
        {
            if (requestBase == null) return null;
            if (!this.CanExecute(requestBase)) return null;

            var response = this.GetResponse(requestBase);
            response.RequestLogId = requestBase.LogId;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract ResponseBase GetResponse(RequestBase requestBase);

        private bool CanExecute(RequestBase requestBase)
        {
            return requestBase.GetType() == this.ValidRequestType;
        }
    }
}
