namespace RequestRouter
{
    using System;

    public abstract class RequestBase
    {
        protected RequestBase()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }
}
