namespace RequestRouter.ProductTwo
{
    using System.Collections.Generic;

    public class StandardResponse : StandardResponseBase
    {
        public StandardResponse()
        {
            this.Subjectivities = new List<string>();
        }

        public string Umr { get; set; }

        public string Type { get; set; }

        public string Insured { get; set; }

        public string InsuredAddress { get; set; }

        public string Interest { get; set; }

        public List<string> Subjectivities { get; }

        public double Premium { get; set; }

        public double InsurersLiability { get; set; }
    }
}
