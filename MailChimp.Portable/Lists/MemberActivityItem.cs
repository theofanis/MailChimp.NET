using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Lists
{
    
    public class MemberActivityItem
    {
        /// <summary>
        /// The action type of the activity item (i.e. sub, unsub, etc)
        /// </summary>
        [JsonProperty("action")]
        public string Action
        {
            get;
            set;
        }

        /// <summary>
        /// The time and date the action occurred
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// The url assoicated with the acitivity item
        /// </summary>
        [JsonProperty("url")]
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// The type of the action. Not every action will have this set.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// The campaign id this activity item was associated with.
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId
        {
            get;
            set;
        }
    }
}
