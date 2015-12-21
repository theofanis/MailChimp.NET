using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MembersResult
    {
        /// <summary>
        /// the total matching records
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// The list of members
        /// </summary>
        [JsonProperty("data")]
        public List<MemberInfo> Data
        {
            get;
            set;
        }
    }
}
