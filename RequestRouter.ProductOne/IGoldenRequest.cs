namespace RequestRouter.ProductOne
{
    using System.Collections.Generic;

    public interface IGoldenRequest
    {
        public string RequestId { get; set; }

        public int Value { get; set; }

        public string BestFriend { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public List<string> Friends { get; }

        public void ConvertToAgentRequest();
    }
}
