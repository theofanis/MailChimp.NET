namespace MailChimp.Reports
{
    using Newtonsoft.Json;

    /// <summary>
    ///optional - common options for controlling returned data
    /// </summary>
    
    public class CommonOptions
    {
        /// <summary>
        /// optional for large data sets, the page number to start at - defaults to 1st page of data (page 0)
        /// </summary>
        [JsonProperty("start")]
        public int Start { get; set; }

        /// <summary>
        /// optional for large data sets, the number of results to return - defaults to 25, upper limit set at 100
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
