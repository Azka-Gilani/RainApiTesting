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
            response = await req.GetRainfallReading(Constants.UrlRainfallMeasurement, createApiRequest);
        }

        [Then(@"Api result is returned")]
        public void ThenApiResultIsReturned()
        {
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Given(@"The user want to have rainfall measurement of a station with reference (.*)")]
        public void GivenTheUserWantToHaveRainfallMeasurementOfAStationWithReference(string station)
        {
            createApiRequest.StationReference = station;
        }

        [When(@"The user sets date as today")]
        public void WhenTheUserSetsDateAsToday()
        {
            DateTime today = DateTime.Now;
            createApiRequest.StartDate = $"{today.Year}-{today.Month:00}-{today.Day:00}";
        }

        [When(@"The user sends request for specific date")]
        public async System.Threading.Tasks.Task WhenTheUserSendsRequestForSpecificDate()
        {
            ApiRequestHelper req = new ApiRequestHelper();
            response = await req.GetRainfallReading(Constants.UrlFloodReadings, createApiRequest);

        }
    }
}
