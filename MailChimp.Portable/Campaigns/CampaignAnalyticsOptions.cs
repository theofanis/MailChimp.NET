using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// optional - one or more of these keys set to the tag to use - that can be any custom text (up to 50 bytes)
    /// </summary>

    public class CampaignAnalyticsOptions
    {
        
        /// <summary>
        /// for Google Analytics tracking
        /// </summary>
        [JsonProperty("google")]
        public string Google
        {
            get;
            set;
        }
        /// <summary>
        /// for ClickTale tracking
        /// </summary>
        [JsonProperty("clicktale")]
        public string Clicktale
        {
            get;
            set;
        }
         /// <summary>
        ///for Goo.al tracking
        /// </summary>
        [JsonProperty("gooal")]
        public string Gooal
        {
            get;
            set;
        }
    }
}
