using Newtonsoft.Json;

namespace RequestManager.App.Models.Response.Brands
{
    public class GetTrendyolBrandByNameResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<TrendyolBrandResponseModel> TrendyolBrands { get; set; }
    }
}
