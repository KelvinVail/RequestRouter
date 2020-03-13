namespace RequestRouter.ProductTwo
{
    using System;

    public class ManagingAgentTwo : ResponderBase
    {
        protected override StandardResponseBase GetResponse(StandardRequestBase standardRequest)
        {
            if (standardRequest is null) return null;
            var standard = (StandardRequest)standardRequest;

            return new MrcResponse
            {
                Umr = standard.Umr,
                Type = standard.Type,
                Insured = standard.Insured,
                InsuredAddress = standard.InsuredAddress,
                Interest = standard.Interest,
                InsurersLiability = 0.5,
                Subjectivities = { "Survey", "Deeds" },
                Premium = Math.Round(standard.LimitsOfLiability * standard.Order * 0.5, 2),
            };
        }
    }
}
