using Newtonsoft.Json;

namespace MailChimp.Campaigns
{

    public class CampaignError
    {
        /// <summary>
        /// the filter that caused the failure
        /// </summary>
        [JsonProperty("filter")]
        public string Filter
        {
            get;
            set;
        }

        /// <summary>
        /// the filter value that caused the failure
        /// </summary>
        [JsonProperty("value")]
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// the error code
        /// </summary>
        [JsonProperty("code")]
        public int Code
        {
            get;
            set;
        }

        /// <summary>
        /// the error message
        /// </summary>
        [JsonProperty("msg")]
        public string Message
        {
            get;
            set;
        }
    }
}
