using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Campaigns
{
    public class CampaignUpdateResult
    {
        /// <summary>
        /// The updated campaign details
        /// </summary>
        [JsonProperty("data")]
        public Campaign Data
        {
            get;
            set;
        }

        /// <summary>
        /// any errors found while updating
        /// </summary>
        [JsonProperty("errors")]
        public List<CampaignUpdateError> Errors
        {
            get;
            set;
        }
    }
}