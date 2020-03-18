namespace RequestRouter.ProductCyber
{

    public class StandardResponse: StandardResponseBase
    {
        public string Currency { get; set; }
        public decimal Premium { get; set; }
        public decimal PremiumTRIA { get; set; }
        public decimal Limit { get; set; }
        public decimal SurplusLinesTax { get; set; }
        public decimal StampingFee { get; set; }
        public decimal AgencyFee { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }


    }
}
