using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Campaign data for each matching campaign
    /// </summary>
    
    public class CampaignForEmail
    {
        /// <summary>
        /// the campaign unique id
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// the campaign's title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// the campaign's subject
        /// </summary>
        [JsonProperty("subject")]
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// the time the campaign was sent
        /// </summary>
        [JsonProperty("send_time")]
        public string SendTime
        {
            get;
            set;
        }

        /// <summary>
        /// the campaign type
        /// </summary>
        [JsonProperty("type")]
        public string CampaignType
        {
            get;
            set;
        }
    }
}
