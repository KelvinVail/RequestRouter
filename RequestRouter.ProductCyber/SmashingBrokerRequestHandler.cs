using System.Collections.Generic;

namespace RequestRouter.ProductCyber
{
    public class SmashingBrokerRequestHandler : RequestHandlerBase
    {
        public SmashingBrokerRequestHandler(IEnumerable<ResponderBase> responders) : base(responders)
        {
        }

        public override ResponseBase FromStandard(StandardResponseBase standardResponse)
        {
            throw new System.NotImplementedException();
        }

        public override StandardRequestBase ToStandard(RequestBase request)
        {
            if (request is null) return null;
            var brokerReq = (SmashingBrokerRequest)request;

            return new StandardRequest {
                LogId = request.LogId,
                Insured = brokerReq.NamedInsured,
                Phone = brokerReq.InsuredPhone,
                BusinessAddress = brokerReq.InsuredBusinessAddress,
                MailingAddress = brokerReq.InsuredMailingAddress,
                PolicyEffectiveDate = brokerReq.PolicyEffectiveDate,
                PolicyExpiriationDate = brokerReq.PolicyExpirationDate,

                YearFounded = brokerReq.YearFounded,
                PriorFiscalYearRevenue = brokerReq.PriorFiscalYearRevenue,
                ProjectedFiscalYearRevenue = brokerReq.ProjectedFiscalYearRevenue,
                NumEmployees = brokerReq.NumberOfEmployees,
                NumProtectedRecords = brokerReq.NumberOfProtectedRecords,
                BusinessClass = brokerReq.BusinessClass,

                Limit = brokerReq.PerOccuranceLimit,
            };
        }
    }
}
