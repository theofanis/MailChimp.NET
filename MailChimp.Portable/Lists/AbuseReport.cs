using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class AbuseReport
    {
        /// <summary>
        /// date/time the abuse report was received and processed
        /// </summary>
        [JsonProperty("date")]
        public string Date
        {
            get;
            set;
        }

        /// <summary>
        /// the email address that reported abuse
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// the unique id for the campaign that report was made against
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }

        /// <summary>
        /// an internal type generally specifying the orginating mail provider - 
        /// may not be useful outside of filling report views
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }
    }
}
