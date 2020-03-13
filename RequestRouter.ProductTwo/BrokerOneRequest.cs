namespace RequestRouter.ProductTwo
{
    public class BrokerOneRequest : RequestBase
    {
        public string Id { get; set; }

        public string InsuranceType { get; set; }

        public string InsuredName { get; set; }

        public string InsuredAddress { get; set; }

        public string InsuredObject { get; set; }

        public double SumInsured { get; set; }

        public double ShareToBePlaced { get; set; }
    }
}
