using System.Collections.Generic;
using Newtonsoft.Json;
using MailChimp.Lists;

namespace MailChimp.Helper
{
    
    public class Match
    {
        /// <summary>
        /// total members matching
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// each entry will be struct matching the data format for a single member as returned by lists/member-info()
        /// </summary>
        [JsonProperty("members")]
        public List<MemberInfo> Members
        {
            get;
            set;
        }
    }
}
