using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace MailChimp.Campaigns
{
    /// <summary>
    /// An individual campaign 'ready check' item
    /// </summary>
    
    public class CampaignReadyCheckItem
    {
        [JsonProperty("type")]
        public string ReadyCheckType { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }
}
