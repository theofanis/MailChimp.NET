using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class StaticSegmentActionResult
    {
        /// <summary>
        /// The segment was removed
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete
        {
            get;
            set;
        }
    }
}
