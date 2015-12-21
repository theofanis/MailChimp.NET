using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class WebhookAddResult
    {
        /// <summary>
        /// the id of the new webhook
        /// </summary>
        [JsonProperty("id")]
        public int WebhookId
        {
            get;
            set;
        }
    }
}
