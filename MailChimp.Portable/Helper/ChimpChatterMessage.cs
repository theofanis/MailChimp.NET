using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Describes a chimp chatter message
    /// </summary>
    
    public class ChimpChatterMessage
    {
        /// <summary>
        /// The chatter message
        /// </summary>
        [JsonProperty("message")]
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the message - one of lists:new-subscriber, lists:unsubscribes, 
        /// lists:profile-updates, campaigns:facebook-likes, 
        /// campaigns:facebook-comments, campaigns:forward-to-friend, 
        /// lists:imports, or campaigns:inbox-inspections
        /// </summary>
        [JsonProperty("type")]
        public string MessageType
        {
            get;
            set;
        }

        /// <summary>
        /// a url into the web app that the message could link to, if applicable
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// the list_id a message relates to, if applicable. Deleted lists will return -DELETED-
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// the list_id a message relates to, if applicable. Deleted campaigns will return -DELETED-
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }

        /// <summary>
        /// The date/time the message was last updated
        /// </summary>
        [JsonProperty("update_time")]
        public string UpdateTime
        {
            get;
            set;
        }
    }
}
