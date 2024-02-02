namespace RequestManager.App.Models.Request
{
    public abstract class BaseRequest
    {
        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// Get a request path
        /// </summary>
        /// <returns>Request path</returns>
        public abstract string GetRequestBaseUri();

        /// <summary>
        /// Get a request path
        /// </summary>
        /// <returns>Request path</returns>
        public abstract string GetRequestPath();

        /// <summary>
        /// Get a request method
        /// </summary>
        /// <returns>Request method</returns>
        public abstract string GetRequestMethod();

        /// <summary>
        /// Get a response is wrapped
        /// </summary>
        /// <returns>Wrapped response</returns>
        public abstract bool IsWrappedResponse();

        #endregion
    }
}
