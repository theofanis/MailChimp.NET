using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    ///  
    /// </summary>
    
    public class StaticSegmentAddResult
    {
        /// <summary>
        /// The ID of the new Static Segment
        /// </summary>
        [JsonProperty("id")]
        public int NewStaticSegmentID
        {
            get;
            set;
        }
    }
}
