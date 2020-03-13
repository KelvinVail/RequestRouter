namespace RequestRouter.ProductTwo
{
    public class StandardRequest : StandardRequestBase
    {
        public string Umr { get; set; }

        public string Type { get; set; }

        public string Insured { get; set; }

        public string InsuredAddress { get; set; }

        public string Interest { get; set; }

        public double LimitsOfLiability { get; set; }

        public double Order { get; set; }
    }
}
