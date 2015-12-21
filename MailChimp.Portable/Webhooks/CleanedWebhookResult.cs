using Newtonsoft.Json;

namespace MailChimp.Webhooks
{
    /// <summary>
    /// The result of a "Cleaned" webhook, when an email fails in mailchimp
    /// </summary>
    
    public class CleanedWebhookResult
    {
        /// <summary>
        /// The type of Webhook e.g. "cleaned"
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// The timestamp of Webhook e.g. "2009-09-26 21:40:57"
        /// </summary>
        [JsonProperty("firedAt")]
        public string FiredAt
        {
            get;
            set;
        }
        /// <summary>
        /// The data from the webhook
        /// </summary>
        [JsonProperty("data")]
        public CleanedWebhookData Data
        {
            get;
            set;
        }
    }
}
