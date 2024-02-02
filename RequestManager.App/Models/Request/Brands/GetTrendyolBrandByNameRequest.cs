using Newtonsoft.Json;
using System.Net;

namespace RequestManager.App.Models.Request.Brands
{
    public class GetTrendyolBrandByNameRequest : BaseRequest
    {

        [JsonIgnore]
        public string BrandName { get; set; }

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetRequestBaseUri() => $"https://api.trendyol.com/sapigw/";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetRequestMethod() => WebRequestMethods.Http.Get;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetRequestPath() => $"brands/by-name?name={BrandName}";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsWrappedResponse() => true;

        #endregion
    }
}
