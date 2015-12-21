using System.Collections.Generic;
using Newtonsoft.Json;
using MailChimp.Lists;

namespace MailChimp.Reports
{
    /// <summary>
    /// a total of all unsubscribed emails and the specific members for this page
    /// </summary>
    
    public class Unsubscribes
    {
        /// <summary>
        /// the total number of unsubscribes for the campaign
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// structs for the email addresses that unsubscribed
        /// </summary>
        [JsonProperty("data")]
        public List<UnsubscribesData> Data { get; set; }
    }

    public class UnsubscribesData
    {
        /// <summary>
        /// the member record as returned by lists/member-info()
        /// </summary>
        [JsonProperty("member")]
        public MemberInfo Member { get; set; }

        /// <summary>
        /// the reason collected for the unsubscribe. If populated, one of 'NORMAL','NOSIGNUP','INAPPROPRIATE','SPAM','OTHER'
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// if the reason is OTHER, the text entered.
        /// </summary>
        [JsonProperty("reason_text")]
        public string ReasonText { get; set; }
    }
}
