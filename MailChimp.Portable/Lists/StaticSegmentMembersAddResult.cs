using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class StaticSegmentMembersAddResult
    {
       
        /// <summary>
        /// the total number of successful updates (will include members already in the segment)
        /// </summary>
        [JsonProperty("success_count")]
        public int successCount
        {
            get;
            set;
        }
        /// <summary>
        /// Error information
        /// </summary>
        [JsonProperty("errors")]
        public List<ListError> Errors
        {
            get;
            set;
        }
    }
}
