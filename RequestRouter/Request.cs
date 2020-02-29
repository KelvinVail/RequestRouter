namespace RequestRouter
{
    using System;

    public abstract class Request
    {
        public static string Id => Guid.NewGuid().ToString();
    }
}
