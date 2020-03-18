namespace RequestRouter.ProductTwo
{
    using System.Collections.Generic;
    using System.Globalization;

    public class BrokerOneRequestHandler : RequestHandlerBase
    {
        public BrokerOneRequestHandler(IEnumerable<ResponderBase> responders)
            : base(responders)
        {
        }

        public override StandardRequestBase ToStandard(RequestBase request)
        {
            if (request is null) return null;
            var baseRequest = (BrokerOneRequest)request;

            return new StandardRequest
            {
                Umr = baseRequest.Id,
                Type = baseRequest.InsuranceType,
                Insured = baseRequest.InsuredName,
                InsuredAddress = baseRequest.InsuredAddress,
                Interest = baseRequest.InsuredObject,
                LimitsOfLiability = baseRequest.SumInsured,
                Order = baseRequest.ShareToBePlaced,
            };
        }

        public override ResponseBase FromStandard(StandardResponseBase standardResponse)
        {
            if (standardResponse is null) return null;
            var standard = (StandardResponse)standardResponse;

            var response = new BrokerOneResponse
            {
                Id = standard.Umr,
                InsuranceType = standard.Type,
                InsuredName = standard.Insured,
                InsuredAddress = standard.InsuredAddress,
                InsuredObject = standard.Interest,
                QuotedPremium = standard.Premium.ToString(new NumberFormatInfo()),
                InsurersShare = standard.InsurersLiability,
            };
            response.DocumentsRequested.AddRange(standard.Subjectivities);

            return response;
        }
    }
}
