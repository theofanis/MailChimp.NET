using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// All content for the campaign
    /// </summary>

    public class CampaignContent
    {
        /// <summary>
        /// The HTML content used for the campaign with merge tags intact
        /// </summary>
        [JsonProperty("html")]
        public string Html
        {
            get;
            set;
        }

        /// <summary>
        /// The Text content used for the campaign with merge tags intact
        /// </summary>
        [JsonProperty("text")]
        public string Text
        {
            get;
            set;
        }
    }
}
