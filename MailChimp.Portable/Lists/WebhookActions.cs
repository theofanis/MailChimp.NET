using Newtonsoft.Json;

namespace MailChimp.Lists
{
    public class WebhookActions
    {
        /// <summary>
        /// triggered when subscribes happen
        /// </summary>
        [JsonProperty("subscribe")]
        public bool Subscribe { get; set; }
        /// <summary>
        /// triggered when unsubscribes happen
        /// </summary>
        [JsonProperty("unsubscribe")]
        public bool Unsubscribe { get; set; }
        /// <summary>
        /// triggered when profile updates happen
        /// </summary>
        [JsonProperty("profile")]
        public bool Profile { get; set; }
        /// <summary>
        /// triggered when a subscriber is cleaned (bounced) from a list
        /// </summary>
        [JsonProperty("cleaned")]
        public bool Cleaned { get; set; }
        /// <summary>
        /// triggered when a subscriber's email address is changed
        /// </summary>
        [JsonProperty("upemail")]
        public bool Upemail { get; set; }
        /// <summary>
        /// triggered when a campaign is sent or canceled
        /// </summary>
        [JsonProperty("campaign")]
        public bool Campaign { get; set; }
    }

}
