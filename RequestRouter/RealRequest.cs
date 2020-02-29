using System.Collections.Generic;
using System.Linq;

namespace RequestRouter
{
    public class RealRequest 
    { 
        public string Id { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public List<string> Friends { get; set; }

        public IGoldenRequest Convert()
        {
            GoldenRequest goldenRequest = new GoldenRequest();
            goldenRequest.RequestId = Id;

            goldenRequest.FirstName = Name.Split(" ")[0];
            goldenRequest.LastName = Name.Split(" ").Last();

            goldenRequest.Value = Cost;
            goldenRequest.BestFriend = Friends.FirstOrDefault();
            goldenRequest.Age = 0;

            goldenRequest.Friends = Friends;

            return goldenRequest;
        }
    }
}
