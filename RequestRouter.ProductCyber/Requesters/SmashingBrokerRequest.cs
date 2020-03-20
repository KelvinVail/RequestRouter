namespace RequestRouter.ProductCyber
{
    using System;

    public class SmashingBrokerRequest : RequestBase
    {
        public string NamedInsured { get; set; }
        public string InsuredPhone { get; set; }
        public string InsuredMailingAddress { get; set; }
        public string InsuredBusinessAddress { get; set; }
        public DateTime PolicyEffectiveDate { get; set; }
        public DateTime PolicyExpirationDate { get; set; }

        public int YearFounded { get; set; }
        public decimal PriorFiscalYearRevenue { get; set; }
        public decimal ProjectedFiscalYearRevenue { get; set; }
        public int NumberOfEmployees { get; set; }
        public int NumberOfProtectedRecords { get; set; }
        public string BusinessClass { get; set; }
        public decimal PerOccuranceLimit { get; set; }
    }
}
