namespace RequestRouter.ProductTwo
{
    using System;
    using System.Threading.Tasks;

    public class ManagingAgentOne : ResponderBase
    {
        protected override async Task<StandardResponseBase> GetResponseAsync(StandardRequestBase standardRequest)
        {
            if (standardRequest is null) return null;
            var standard = (StandardRequest)standardRequest;

            return await Task.FromResult(new StandardResponse
            {
                Umr = standard.Umr,
                Type = standard.Type,
                Insured = standard.Insured,
                InsuredAddress = standard.InsuredAddress,
                Interest = standard.Interest,
                InsurersLiability = 0.2,
                Subjectivities = { "Property Survey" },
                Premium = Math.Round(standard.LimitsOfLiability * standard.Order * 0.2, 2),
            });
        }
    }
}
