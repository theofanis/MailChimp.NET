using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MemberActivityResult
    {
        /// <summary>
        /// The number of subscribers successfully found on the list
        /// </summary>
        [JsonProperty("success_count")]
        public int SuccessCount
        {
            get;
            set;
        }

        /// <summary>
        /// The number of subscribers who were not found on the list
        /// </summary>
        [JsonProperty("error_count")]
        public int ErrorCount
        {
            get;
            set;
        }

        /// <summary>
        /// List of members information
        /// </summary>
        [JsonProperty("data")]
        public List<MemberActivity> Data
        {
            get;
            set;
        }
    }
}
