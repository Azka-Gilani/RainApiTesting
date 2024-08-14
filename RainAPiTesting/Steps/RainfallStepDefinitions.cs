using TechTalk.SpecFlow;
using RainApiTesting.Models;
using RainApiTesting.Helpers;
using RestSharp;
using NUnit.Framework;

namespace RainApiTesting.Steps
{
    [Binding]
    public class RainfallStepDefinitions
    {
        private readonly CreateApiRequest createApiRequest;
        private RestResponse response;

        public RainfallStepDefinitions(CreateApiRequest createApiRequest)
        {
            this.createApiRequest = createApiRequest;
        }
        [Given(@"The user want to have rainfall measurement of station (.*)")]
        public void GivenTheUserWantToHaveRainfallMeasurementOfStation(string station)
        {
            createApiRequest.Station = station;
        }
        [When(@"The user sets parameter as (.*)")]
        public void WhenTheUserSetsParameterAsRainfall(string param)
        {
            createApiRequest.Param = param;
        }

        [When(@"The user includes limit parameter with limit set as (.*)")]
        public void WhenTheUserIncludesLimitParameterWithLimitSetAs(string limit)
        {
            createApiRequest.Limit = limit;
        }

        [When(@"The user sends request for individaual station")]
        public async System.Threading.Tasks.Task WhenTheUserSendsRequestForIndividaualStation()
        {
            ApiRequestHelper req = new ApiRequestHelper();
            response = await req.GetRainfallReading("http://environment.data.gov.uk/flood-monitoring/id/stations?", createApiRequest);
        }

        [Then(@"Api result is returned")]
        public void ThenApiResultIsReturned()
        {
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
