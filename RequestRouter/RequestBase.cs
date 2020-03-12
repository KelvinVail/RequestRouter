namespace RequestRouter
{
    using System;

    public abstract class RequestBase
    {
        protected RequestBase()
        {
            this.LogId = Guid.NewGuid().ToString();
        }

        public string LogId { get; set; }
    }
}
