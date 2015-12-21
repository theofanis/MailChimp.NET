using Newtonsoft.Json;

namespace MailChimp
{
    
    public class CampaignSegmentTestResult
    {
        /// <summary>
        /// The total number of subscribers matching your segmentation options
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }
    }
}
