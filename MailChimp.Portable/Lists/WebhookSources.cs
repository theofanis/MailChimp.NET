using Newtonsoft.Json;

namespace MailChimp.Lists
{
    public class WebhookSources
    {
        /// <summary>
        /// whether user/subscriber triggered actions are returned
        /// </summary>
        [JsonProperty("user")]
        public bool User { get; set; }
        /// <summary>
        /// whether admin (manual, in-app) triggered actions are returned
        /// </summary>
        [JsonProperty("admin")]
        public bool Admin { get; set; }
        /// <summary>
        /// whether api triggered actions are returned
        /// </summary>
        [JsonProperty("api")]
        public bool Api { get; set; }
    }

}
