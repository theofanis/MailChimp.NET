using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// the total of all reports and the specific reports 
    /// </summary>
    
    public class AbuseResult
    {
        /// <summary>
        /// the total number of matching abuse reports
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// the actual data for each report
        /// </summary>
        [JsonProperty("data")]
        public List<AbuseReport> Data
        {
            get;
            set;
        }
    }
}
