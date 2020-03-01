namespace RequestRouter
{
    public abstract class ResponseBase
    {
        public string RequestId { get; internal set; }

        public string ResponderName { get; internal set; }
    }
}
