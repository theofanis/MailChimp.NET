using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MemberInfoResult
    {
        /// <summary>
        /// the number of subscribers successfully found on the list
        /// </summary>
        [JsonProperty("success_count")]
        public int SuccessCount
        {
            get;
            set;
        }

        /// <summary>
        /// the number of subscribers who were not found on the list
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
        public List<MemberInfo> Data
        {
            get;
            set;
        }
    }
}
