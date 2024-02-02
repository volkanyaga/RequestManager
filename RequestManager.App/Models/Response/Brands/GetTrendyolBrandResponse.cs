using Newtonsoft.Json;

namespace RequestManager.App.Models.Response.Brands
{
    public class GetTrendyolBrandResponse : BaseResponse
    {
        [JsonProperty("brands")]
        public List<TrendyolBrandResponseModel> TrendyolBrands { get; set; }
    }
}
