using RequestManager.App.Models.Request;
using RequestManager.App.Models.Request.Brands;
using RequestManager.App.Models.Response.Brands;
using RequestManager.App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.App.Services
{
    public class TrendyolRequestManager
    {

        #region Fields

        #endregion

        #region Ctor

        #endregion

        #region Get All Brands

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetTrendyolBrandResponse GetAllTrendyolBrands(GetTrendyolBrandRequest request)
        {
            return Base.RequestManager.ProcessPlatformRequest<GetTrendyolBrandRequest, GetTrendyolBrandResponse>(request);
        }

        #endregion

        #region Get Brand By Name

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetTrendyolBrandByNameResponse SearchTrendyolBrands(GetTrendyolBrandByNameRequest request) 
        {
            return Base.RequestManager.ProcessPlatformRequest<GetTrendyolBrandByNameRequest, GetTrendyolBrandByNameResponse>(request);
        }

        #endregion
    }
}
