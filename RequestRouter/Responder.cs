namespace RequestRouter
{
    using System;

    public abstract class Responder
    {
        protected abstract Type ValidRequestType { get; }

        internal Response Execute(Request request)
        {
            if (request == null) return null;
            if (!this.CanExecute(request)) return null;

            var response = this.GetResponse(request);
            response.RequestId = request.Id;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract Response GetResponse(Request request);

        private bool CanExecute(Request request)
        {
            return request.GetType() == this.ValidRequestType;
        }
    }
}
