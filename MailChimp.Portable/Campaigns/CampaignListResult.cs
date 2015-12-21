using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// a count of all matching campaigns, the specific ones for the current page, 
    /// and any errors from the filters provided
    /// </summary>
    
    public class CampaignListResult
    {
        /// <summary>
        /// the total number of campaigns matching the filters passed in
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// A list of campaigns returned
        /// </summary>
        [JsonProperty("data")]
        public List<Campaign> Data
        {
            get;
            set;
        }

        /// <summary>
        /// any errors found while loading lists [sic] - usually 
        /// just from providing invalid list ids
        /// </summary>
        [JsonProperty("errors")]
        public List<CampaignError> Errors
        {
            get;
            set;
        }
    }
}
