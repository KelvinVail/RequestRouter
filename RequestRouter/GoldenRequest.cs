namespace RequestRouter
{
    internal class GoldenRequest : IGoldenRequest
    {
        public string RequestId { get; set; }
        public int Value { get; set; }
        public string BestFriend { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public void ConvertToBrokerRequest()
        {
            throw new System.NotImplementedException();
        }
    }
}
