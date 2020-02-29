namespace RequestRouter
{
    using System.Collections.Generic;

    public sealed class Router
    {
        public IEnumerable<Response> GetResponses(Request request)
        {
            return new List<Response>();
        }
    }
}
