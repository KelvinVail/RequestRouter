﻿namespace RequestRouter
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Router
    {
        private readonly IEnumerable<Responder> responders;

        public Router(IEnumerable<Responder> responders)
        {
            this.responders = responders;
        }

        public IEnumerable<Response> GetResponses(Request request)
        {
            return this.responders.Select(r => r.Execute(request));
        }
    }
}
