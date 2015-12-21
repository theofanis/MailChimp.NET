using Newtonsoft.Json;
using MailChimp.Campaigns;

namespace MailChimp.Lists
{
    
    public class AddCampaignSegmentOptions
    {
        /// <summary>
        /// either "static" or "saved" 
        /// </summary>
        [JsonProperty("type")]
        public string SegmentType { get; set; }

        /// <summary>
        /// a unique name per list for the segment - 100 byte maximum length, anything longer will throw an error 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// various options for the new segment 
        /// </summary>
        [JsonProperty("segment_opts")]
        public CampaignSegmentOptions SegmentOptions { get; set; }
    }
}