namespace RequestRouter
{
    public abstract class Response
    {
        public string RequestId { get; internal set; }

        public string ResponderName { get; internal set; }
    }
}
