namespace RequestRouter
{
    public abstract class StandardResponseBase
    {
        public string RequestLogId { get; internal set; }

        public string ResponderName { get; internal set; }
    }
}
