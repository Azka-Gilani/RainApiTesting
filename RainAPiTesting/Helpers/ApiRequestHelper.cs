using RainApiTesting.Models;
using RestSharp;

namespace RainApiTesting.Helpers
{
    public class ApiRequestHelper
    {
        private RestClient client;
        private RestRequest request;
        public RestClient SetUrl(string baseUrl)
        {
            client = new RestClient(baseUrl);
            return client;
        }

        public RestRequest CreateGetRequestWithParams(CreateApiRequest createApiRequest)
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            if (createApiRequest.Param !=null)
                request.AddParameter("parameter", createApiRequest.Param);
            if (createApiRequest.Station != null)
                request.AddParameter("search", createApiRequest.Station);
            if (createApiRequest.Limit != null)
                request.AddParameter("_limit", createApiRequest.Limit);
            if (createApiRequest.StationReference != null)
                request.AddParameter("stationReference", createApiRequest.StationReference);
            if (createApiRequest.StartDate != null)
                request.AddParameter("startdate", createApiRequest.StartDate);
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }

            });
            return request;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }

        public async Task<RestResponse> GetRainfallReading(string baseUrl, CreateApiRequest createApiRequest)
        {
            var client = this.SetUrl(baseUrl);
            var request = this.CreateGetRequestWithParams(createApiRequest);
            request.RequestFormat = DataFormat.Json;
            var response = await this.GetResponseAsync(client, request);
            return response;
        }
    }
}
