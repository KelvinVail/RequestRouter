﻿namespace RequestRouter.ProductTwo.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class Examples
    {
        [Fact]
        public async Task ExampleOne()
        {
            var request = new BrokerOneRequest
            {
                Id = "BrokerOne/ABC1234",
                InsuranceType = "Property",
                InsuredName = "Lloyd",
                InsuredAddress = "One Lime Street",
                InsuredObject = "Lloyd's Building",
                SumInsured = 100000000,
                ShareToBePlaced = 1,
            };

            var responders = new List<ResponderBase>
            {
                new ManagingAgentOne(),
                new ManagingAgentTwo(),
                new ManagingAgentThree(),
            };

            var handler = new BrokerOneRequestHandler(responders);

            var responses = await handler.GetResponsesAsync(request);

            Assert.True(responses.Count() == 3);
        }

        [Fact]
        public async Task ExampleOfStandardRequest()
        {
            var request = new StandardRequest
            {
                Umr = "BrokerOne/ABC1234",
                Type = "Property",
                Insured = "Lloyd",
                InsuredAddress = "One Lime Street",
                Interest = "Lloyd's Building",
                LimitsOfLiability = 100000000,
                Order = 1,
            };

            var responders = new List<ResponderBase>
            {
                new ManagingAgentOne(),
                new ManagingAgentTwo(),
                new ManagingAgentThree(),
            };

            var handler = new StandardHandler(responders);

            var responses = await handler.GetResponsesAsync(request);

            Assert.True(responses.Count() == 3);
        }
    }
}
