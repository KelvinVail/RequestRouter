namespace RequestRouter
{
    using System;

    public abstract class Request
    {
        protected Request()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }
    }
}
