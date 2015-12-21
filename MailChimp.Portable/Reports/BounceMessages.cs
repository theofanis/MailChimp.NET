using System.Collections.Generic;
using Newtonsoft.Json;
using MailChimp.Lists;

namespace MailChimp.Reports
{
    /// <summary>
    ///optional - various options for controlling returned data
    /// </summary>
    
    public class BounceMessagesOptions : CommonOptions
    {
        /// <summary>
        /// optional pull only messages since this time - 24 hour format in GMT, eg "2013-12-30 20:30:00"
        /// </summary>
        [JsonProperty("since")]
        public string Since { get; set; }

    }

    /// <summary>
    /// data for the full bounce messages for this campaign
    /// </summary>
    
    public class BounceMessages
    {
        /// <summary>
        /// that total number of bounce messages for the campaign
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// structs containing the data for this page
        /// </summary>
        [JsonProperty("data")]
        public List<BounceMessagesData> Data { get; set; }
    }

    
    public class BounceMessagesData
    {
        /// <summary>
        /// the member record as returned by lists/member-info()
        /// </summary>
        [JsonProperty("member")]
        public MemberInfo Member { get; set; }        

        /// <summary>
        /// date the bounce was received and processed
        /// </summary>
        [JsonProperty("date")]
        public  string Date { get; set; }

        /// <summary>
        /// the entire bounce message received
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
