namespace RequestRouter.ProductCyber
{
    public class SmashingBrokerResponse: ResponseBase
    {
        public string Currency { get; set; }
        public decimal AnnualPremium { get; set; }
        public decimal AnnualPremiumTRIA { get; set; }
        public decimal GeneralAggregateLimit { get; set; }
        public decimal EstimatedSurplusLInesTax { get; set; }
        public decimal EstimatedStampingFee { get; set; }
        public decimal AgencyFee { get; set; }
        public string Notes { get; set; }
    }
}
