using Newtonsoft.Json;
using System.Collections.Generic;
using MailChimp.Lists;

namespace MailChimp.Reports
{
    
     /// <summary>
    ///optional - various options for controlling returned data
    /// </summary>
    
    public class SentToLimits : CommonOptions
    {
       /// <summary>
       /// optional the status to pull - one of 'sent', 'hard' (bounce), or 'soft' (bounce). By default, all records are returned
       /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

    }

    /// <summary>
    ///  a total of all matching emails and the specific emails for this page
    /// </summary>
    
    public class SentToMembers
    {
        /// <summary>
        /// the total number of members for the campaign and status
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// structs for each campaign member matching
        /// </summary>
        [JsonProperty("data")]
        public List<SentToMemberData> Data { get; set; }
    }

    
    public class SentToMemberData
    {
        /// <summary>
        /// the member record as returned by lists/member-info()
        /// </summary>
        [JsonProperty("member")]
        public MemberInfo Member { get; set; }

        /// <summary>
        /// the status of the send - one of 'sent', 'hard', 'soft'
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// if this was an absplit campaign, one of 'a','b', or 'winner'
        /// </summary>
        [JsonProperty("absplit_group")]
        public string AbsplitGroup { get; set; }

        /// <summary>
        /// if this was an timewarp campaign the timezone GMT offset the member was included in
        /// </summary>
        [JsonProperty("tz_group")]
        public string TZGroup { get; set; }
    }
}
