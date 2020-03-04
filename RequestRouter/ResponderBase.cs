namespace RequestRouter
{
    using System;

    public abstract class ResponderBase
    {
        protected abstract Type ValidRequestType { get; }

        internal StandardResponseBase Execute(StandardRequestBase standardRequestBase)
        {
            if (standardRequestBase == null) return null;
            if (!this.CanExecute(standardRequestBase)) return null;

            var response = this.GetResponse(standardRequestBase);
            response.RequestLogId = standardRequestBase.LogId;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract StandardResponseBase GetResponse(StandardRequestBase standardRequestBase);

        private bool CanExecute(StandardRequestBase standardRequestBase)
        {
            return standardRequestBase.GetType() == this.ValidRequestType;
        }
    }
}
