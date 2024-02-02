using Newtonsoft.Json;
using RequestManager.App.Helpers;
using RequestManager.App.Models.Request;
using RequestManager.App.Models.Response;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace RequestManager.App.Services.Base
{
    public static class RequestManager
    {
        /// <summary>
        /// Process request
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="request">Request</param>
        /// <returns>Response</returns>
        private static TResponse ProcessRequest<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest where TResponse : BaseResponse
        {
            //create requesting URL
            var url = $"{request.GetRequestBaseUri()}{request.GetRequestPath()}";

            //create web request
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = request.GetRequestMethod();
            webRequest.Accept = "application/json";
            webRequest.ContentType = "application/json";

            // Define a cache policy for this request only. 
            webRequest.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

            //add authorization header
            //if ()
            //{
            //    var encodedSecurityKey = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{}:{}"));
            //    webRequest.Headers.Add(HttpRequestHeader.Authorization, $"Basic {encodedSecurityKey}");
            //}

            //create post data
            if (request.GetRequestMethod() != WebRequestMethods.Http.Get)
            {
                var requestString = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                var postData = Encoding.UTF8.GetBytes(requestString);
                webRequest.ContentLength = postData.Length;

                using (var stream = webRequest.GetRequestStream())
                    stream.Write(postData, 0, postData.Length);
            }

            //get response
            var httpResponse = (HttpWebResponse)webRequest.GetResponse();
            var responseMessage = string.Empty;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                responseMessage = streamReader.ReadToEnd();

            //wrapped respnse
            if (!string.IsNullOrWhiteSpace(responseMessage) && request.IsWrappedResponse())
                responseMessage = responseMessage.ToWrappedJson();

            //return result
            return JsonConvert.DeserializeObject<TResponse>(responseMessage);
        }

        /// <summary>
        /// Process platform request
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="request">Request</param>
        /// <returns>Response</returns>
        public static TResponse ProcessPlatformRequest<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest where TResponse : BaseResponse
        {
            try
            {
                //process request action
                return ProcessRequest<TRequest, TResponse>(request);
            }
            catch (Exception exception)
            {
                var errorMessage = $"Error: {exception.Message}.";
                string errorResponse = null;
                try
                {
                    //try to get error response
                    if (exception is WebException webException)
                    {
                        var httpResponse = (HttpWebResponse)webException.Response;
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            errorResponse = streamReader.ReadToEnd();
                            errorMessage = $"{errorMessage} Details: {errorResponse}";
                            return JsonConvert.DeserializeObject<TResponse>(errorResponse);
                        }
                    }
                }
                catch { }
                finally
                {
                    //Logging

                }

                return default;
            }

        }
    }
}
