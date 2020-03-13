namespace RequestRouter.ProductTwo
{
    using System.Collections.Generic;

    public class BrokerOneResponse : ResponseBase
    {
        public BrokerOneResponse()
        {
            this.DocumentsRequested = new List<string>();
        }

        public string Id { get; set; }

        public string InsuranceType { get; set; }

        public string InsuredName { get; set; }

        public string InsuredAddress { get; set; }

        public string InsuredObject { get; set; }

        public List<string> DocumentsRequested { get; }

        public string QuotedPremium { get; set; }

        public double InsurersShare { get; set; }
    }
}
