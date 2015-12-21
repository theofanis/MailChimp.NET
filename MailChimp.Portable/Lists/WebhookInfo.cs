using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// result of the operation including valid data and any errors
    /// </summary>
    
    public class WebhookInfo
    {
        /// <summary>
        /// the URL for this Webhook
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// the possible actions and whether they are enabled
        /// </summary>
        [JsonProperty("actions")]
        public WebhookActions Actions
        {
            get;
            set;
        }

        /// <summary>
        /// the possible sources and whether they are enabled
        /// </summary>
        [JsonProperty("sources")]
        public WebhookSources Sources
        {
            get;
            set;
        }
    }

}
