using Newtonsoft.Json;
using Newtonsoft.Json;

namespace MailChimp.Campaigns
{
    
    public class CampaignActionResult
    {
        /// <summary>
        /// whether the call worked. Realistically 
        /// this will always be true as errors will 
        /// be thrown otherwise.
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete
        {
            get;
            set;
        }
    }
}
