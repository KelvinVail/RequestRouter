namespace RequestRouter
{
    public abstract class RequestBase
    {
        public abstract StandardRequestBase ToStandard();

        public abstract ResponseBase FromStandard(StandardResponseBase standardResponse);
    }
}
