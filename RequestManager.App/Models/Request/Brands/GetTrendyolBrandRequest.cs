using Newtonsoft.Json;
using System.Net;

namespace RequestManager.App.Models.Request.Brands
{
    public class GetTrendyolBrandRequest : BaseRequest
    {
        public GetTrendyolBrandRequest()
        {
            PageIndex = 0;
            PageIndex = 100;
        }

        [JsonIgnore]
        public int PageIndex { get; set; }

        [JsonIgnore]
        public int PageSize { get; set; }

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
        public override string GetRequestPath() => $"brands?page={PageIndex}&size={PageSize}";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsWrappedResponse() => false;

        #endregion

    }
}
