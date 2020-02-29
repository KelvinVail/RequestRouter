namespace RequestRouter.ProductOne
{
    using System.Collections.Generic;
    using System.Linq;

    public class RealRequest
    {
        public string Id { get; set; }

        public int Cost { get; set; }

        public string Name { get; set; }

        public List<string> Friends { get; } = new List<string>();

        public IGoldenRequest Convert()
        {
            var goldenRequest = new GoldenRequest
            {
                RequestId = this.Id,
                FirstName = this.Name.Split(" ")[0],
                LastName = this.Name.Split(" ").Last(),
                Value = this.Cost,
                BestFriend = this.Friends.FirstOrDefault(),
                Age = 0,
                Friends = this.Friends,
            };

            return goldenRequest;
        }
    }
}
