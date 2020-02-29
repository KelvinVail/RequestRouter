namespace RequestRouter.ProductOne
{
    using System.Collections.Generic;
    using System.Linq;

    public class RealRequest
    {
        public RealRequest()
        {
            this.Friends = new List<string>();
        }

        public string Id { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }

        public List<string> Friends { get; }

        public GoldenRequest Convert()
        {
            var goldenRequest = new GoldenRequest
            {
                RequestId = this.Id,
                FirstName = this.Name.Split(" ")[0],
                LastName = this.Name.Split(" ").Last(),
                Value = this.Cost,
                BestFriend = this.Friends.FirstOrDefault(),
                Age = 0,
            };

            return goldenRequest;
        }
    }
}
