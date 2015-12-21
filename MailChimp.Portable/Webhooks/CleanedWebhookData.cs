using Newtonsoft.Json;

namespace MailChimp.Webhooks
{
    
    public class CleanedWebhookData
    {
        /// <summary>
        /// The list ID that the email address was cleaned from
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }
        /// <summary>
        /// The campaign ID that the email address was cleaned from
        /// </summary>
        [JsonProperty("campaign_id")]
        public string Campaign_Id
        {
            get;
            set;
        }
        /// <summary>
        /// The reason the email address was cleaned will be one of "hard" (for hard bounces) or "abuse"
        /// </summary>
        [JsonProperty("reason")]
        public string Reason
        {
            get;
            set;
        }
        /// <summary>
        /// Email address that was cleaned
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

    }
}
