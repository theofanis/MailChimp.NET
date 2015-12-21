using System;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class SavedSegmentResult
    {
        /// <summary>
        /// the id of the segment
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// the name of the segment
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// same match+conditions struct typically used
        /// </summary>
        [JsonProperty("segment_opts")]
        public string SegmentOpts
        {
            get;
            set;
        }
        /// <summary>
        /// a textual description of the segment match/conditions
        /// </summary>
        [JsonProperty("segment_text")]
        public string SegmentText
        {
            get;
            set;
        }
        
        /// <summary>
        /// the date+time the segment was created
        /// </summary>
        [JsonProperty("created_date")]
        public DateTime CreatedDate
        {
            get;
            set;
        }

        /// <summary>
        /// the date+time the segment was last updated (add or del)
        /// </summary>
        [JsonProperty("last_update")]
        public DateTime LastUpdate
        {
            get;
            set;
        }
    }
}
