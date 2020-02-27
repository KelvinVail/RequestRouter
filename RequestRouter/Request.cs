using System;
using System.Collections.Generic;

namespace RequestRouter
{
    public class Request 
    { 
        public string Id { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public List<string> Friends { get; set; }

        public IGoldenRequest Convert()
        {
            return new GoldenRequest();
        }
    }
}
