namespace RequestRouter.ProductCyber.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    public class SmashingBrokerTests
    {
        [Fact]
        public void SamshingBrokerRequestExists() {
            var req = new SmashingBrokerRequest();
        }

        [Fact]
        public void SmashingBrokerRequestImplementsRequestBase()
        {
            var req = new SmashingBrokerRequest();
            Assert.IsAssignableFrom<RequestBase>(req);
        }

        [Fact]
        public void CanConvertSmashingBrokerRequestToStandardRequest()
        {
            var req = new SmashingBrokerRequest {
                
                // General Information
                LogId = Guid.NewGuid().ToString(),
                NamedInsured = "Fraternal Society Inc",
                InsuredPhone = "(123) 456-7890",
                InsuredMailingAddress = "100 Second St, Belle Chasse, LA, 70037",
                InsuredBusinessAddress = "100 Second St, Belle Chasse, LA, 70037",
                PolicyEffectiveDate =  Convert.ToDateTime("01/11/2019"),
                PolicyExpirationDate = Convert.ToDateTime("01/11/2020"),
                
                // Business Information Fields
                YearFounded = 1995,
                PriorFiscalYearRevenue = 250000,
                ProjectedFiscalYearRevenue = 350000,
                NumberOfEmployees = 20,
                NumberOfProtectedRecords = 100,
                BusinessClass = "Fraternal Society or Association",
                
                // Limits
                PerOccuranceLimit = 500000,
            };
            var handler = new SmashingBrokerRequestHandler(new List<ResponderBase>());
            var standardReq = (StandardRequest)handler.ToStandard(req);
            Assert.IsType<StandardRequest>(standardReq);
            Assert.Equal(req.NamedInsured, standardReq.Insured);
        }



        [Fact]
        public void SmashingBrokerResponseExists() 
        {
            var res = new SmashingBrokerResponse();
        }

        [Fact]
        public void CanConvertFromStandardResponseToSmashingBrokerResponse() 
        {
            var standardResponse = new StandardResponse();

            var handler = new SmashingBrokerRequestHandler(new List<ResponderBase>());
            var res = handler.FromStandard(standardResponse);

            Assert.IsAssignableFrom<ResponseBase>(res);


        }

    }



}
