namespace RequestManager.App.Helpers
{
    public static class CommonHelper
    {
        /// <summary>
        /// Wrapped json response
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Result</returns>
        public static string ToWrappedJson(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return value;

            //replace value
            value = "{\"Data\":" + value + "}";
            return value;
        }

    }
}
