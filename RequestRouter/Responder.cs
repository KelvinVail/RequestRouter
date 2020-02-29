namespace RequestRouter
{
    using System;

    public abstract class Responder
    {
        protected abstract Type ValidRequestType { get; }

        public Response Execute(Request request)
        {
            return this.CanExecute(request) ? this.GetResponse(request) : null;
        }

        protected abstract Response GetResponse(Request request);

        private bool CanExecute(Request request)
        {
            if (request == null) return false;
            return request.GetType() == this.ValidRequestType;
        }
    }
}
