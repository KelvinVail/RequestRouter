namespace RequestRouter
{
    public abstract class ResponseBase
    {
        public string RequestLogId { get; internal set; }

        public string ResponderName { get; internal set; }
    }
}
