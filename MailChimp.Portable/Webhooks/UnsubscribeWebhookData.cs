using MailChimp.Lists;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Webhooks
{
    /// <summary>
    /// Data returned from an Unsubscribe Webhook
    /// </summary>
    
    public class UnsubscribeWebhookData
    {
        /// <summary>
        /// The action performed
        /// </summary>
        [JsonProperty("action")]
        public string Action
        {
            get;
            set;
        }

        /// <summary>
        /// The unsubscribe reason if given
        /// </summary>
        [JsonProperty("reason")]
        public string Reason
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the member
        /// </summary>
        [JsonProperty("id")]
        public string ID
        {
            get;
            set;
        }

        /// <summary>
        /// The ID of the list they unsubscribed from
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// The email address that was unsubscribed
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// The type of email e.g. "Html"
        /// </summary>
        [JsonProperty("email_type")]
        public string EmailType
        {
            get;
            set;
        }

        /// <summary>
        /// The merges supplied
        /// </summary>
        [JsonProperty("merges")]
        public MergeVar Merges
        {
            get;
            set;
        }

        /// <summary>
        /// IP address
        /// </summary>
        [JsonProperty("ip_opt")]
        public string IPOpt
        {
            get;
            set;
        }

        /// <summary>
        /// Campaign ID
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignID
        {
            get;
            set;
        }

    }
}
