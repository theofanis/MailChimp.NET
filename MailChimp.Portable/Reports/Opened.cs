using System.Collections.Generic;
using Newtonsoft.Json;
using MailChimp.Lists;

namespace MailChimp.Reports
{
    /// <summary>
    ///optional - various options for controlling returned data
    /// </summary>
    
    public class OpenedOptions : CommonOptions
    {
        /// <summary>
        /// optional the data to sort by - "opened" (order opens occurred, default) or "opens" (total number of opens). Invalid fields will fall back on the default.
        /// </summary>
        [JsonProperty("sort_field")]
        public string SortField { get; set; }

        /// <summary>
        /// optional the direct - ASC or DESC. defaults to ASC (case insensitive)
        /// </summary>
        [JsonProperty("sort_dir")]
        public string SortDirection { get; set; }

    }


    /// <summary>
    /// containing the total records matched and the specific records for this page
    /// </summary>
    
    public class Opened
    {
        /// <summary>
        /// the total number of records matched
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// structs for the actual opens data, including:
        /// </summary>
        [JsonProperty("data")]
        public List<OpenedData> Data { get; set; }
    }

    
    public class OpenedData
    {
        /// <summary>
        /// the member record as returned by lists/member-info()
        /// </summary>
        [JsonProperty("member")]
        public MemberInfo Member { get; set; }        

        /// <summary>
        /// Total number of times the campaign was opened by this email address
        /// </summary>
        [JsonProperty("opens")]
        public  int Opens { get; set; }
    }
}
