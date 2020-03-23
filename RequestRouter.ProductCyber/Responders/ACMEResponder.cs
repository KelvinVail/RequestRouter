namespace RequestRouter.ProductCyber.Responders
{
    using System.Threading.Tasks;

    public class ACMEResponder : ResponderBase
    {
        protected override async Task<StandardResponseBase> GetResponseAsync(StandardRequestBase standardRequest)
        {
            var standardResponse = new StandardResponse
            {
                Premium = 8394.00m,
                PremiumTRIA = 755.00m,
                Limit = 2000000.00m,
                SurplusLinesTax = 411.96m,
                StampingFee = 12.74m,
                AgencyFee = 100.00m,
                Details = @"The tax calculation rates and percentages are for informational purposes only. 
                            We are not responsible for accurate and timely tax filings unless otherwise mutually agreed
                            to in writing between both parties. Certain ploicies may be subject to an additional $250 inspection fee.",
            };

            return await Task.FromResult(standardResponse);
        }
    }
}
