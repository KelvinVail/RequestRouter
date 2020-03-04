namespace RequestRouter
{
    using System;

    public abstract class StandardRequestBase
    {
        protected StandardRequestBase()
        {
            this.LogId = Guid.NewGuid().ToString();
        }

        public string LogId { get; }
    }
}
