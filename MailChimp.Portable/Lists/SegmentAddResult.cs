using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    ///  
    /// </summary>
    
    public class SegmentAddResult
    {
        /// <summary>
        /// The ID of the new Segment
        /// </summary>
        [JsonProperty("id")]
        public int NewSegmentID
        {
            get;
            set;
        }
    }
}