using RequestRouter.ProductCyber.Responders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace RequestRouter.ProductCyber
{
    public class ACMEResponder : ResponderBase
    {
        protected override StandardResponseBase GetResponse(StandardRequestBase standardRequest)
        {

            var standardResponse = new StandardResponse
            {
                Premium = 8394.00m,
                PremiumTRIA = 755.00m,
                Limit = 2000000.00m,
                SurplusLinesTax = 411.96m,
                StampingFee = 12.74m,
                AgencyFee = 100.00m,
                Details = "Lasdkjgasdg ahs dash asdkjh kj",
            };

            return standardResponse;
        }

        
    }
}
