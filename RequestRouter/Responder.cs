namespace RequestRouter
{
    using System;

    public abstract class Responder
    {
        protected abstract Type ValidRequestType { get; }

        public Response Execute(Request request)
        {
            if (!this.CanExecute(request)) return null;

            var response = this.GetResponse(request);
            response.RequestId = request?.Id;
            response.ResponderName = this.GetType().Name;
            return response;
        }

        protected abstract Response GetResponse(Request request);

        private bool CanExecute(Request request)
        {
            if (request == null) return false;
            return request.GetType() == this.ValidRequestType;
        }
    }
}
