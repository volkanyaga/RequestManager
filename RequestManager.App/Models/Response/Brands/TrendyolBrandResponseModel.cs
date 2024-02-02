using Newtonsoft.Json;

namespace RequestManager.App.Models.Response.Brands
{
    public class TrendyolBrandResponseModel
    {
        [JsonProperty("id")]
        public int BrandId { get; set; }

        [JsonProperty("name")]
        public string BrandName { get; set; }
    }

}
