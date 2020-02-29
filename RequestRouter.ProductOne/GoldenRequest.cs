namespace RequestRouter.ProductOne
{
    using System.Collections.Generic;

    public class GoldenRequest : Request
    {
        public GoldenRequest()
        {
            this.Friends = new List<string>();
        }

        public string RequestId { get; set; }

        public int Value { get; set; }

        public List<string> Friends { get; }

        public string BestFriend { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
