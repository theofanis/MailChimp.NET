using System;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class StaticSegmentResult
    {
        /// <summary>
        /// the id of the segment
        /// </summary>
        [JsonProperty("id")]
        public int StaticSegmentId
        {
            get;
            set;
        }
        /// <summary>
        /// the name of the segment
        /// </summary>
        [JsonProperty("name")]
        public string SegmentName
        {
            get;
            set;
        }
        /// <summary>
        /// the total number of subscribed members currently in a segment 
        /// </summary>
        [JsonProperty("member_count")]
        public string memberCount
        {
            get;
            set;
        }
        /// <summary>
        /// the date/time the segment was created 
        /// </summary>
        [JsonProperty("created_date")]
        public DateTime createdDate
        {
            get;
            set;
        }
        /// <summary>
        /// the date/time the segment was last updated (add or del)
        /// </summary>
        [JsonProperty("last_update")]
        public DateTime lastUpdate
        {
            get;
            set;
        }
        /// <summary>
        /// the date/time the segment was last reset (ie had all members cleared from it)
        /// </summary>
        [JsonProperty("last_reset")]
        public DateTime lastReset
        {
            get;
            set;
        }

    }
}
