using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    
    public class CampaignUpdateError
    {

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

        /// <summary>
        /// the parameter name that failed
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
    }
}
