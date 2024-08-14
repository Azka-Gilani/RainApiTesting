namespace RainApiTesting.Models
{
    public class CreateApiRequest
    {
        public string Station { get; set; }
        public string Limit { get; set; }
        public string Param { get; set; }
        public string StartDate { get; set; }
        public string StationReference { get; set; }
    }
}
