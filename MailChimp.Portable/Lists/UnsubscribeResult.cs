using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class UnsubscribeResult
    {
        /// <summary>
        /// whether the call worked. reallistically this will always be true as errors will be thrown otherwise.
        /// </summary>
        [JsonProperty("complete")]
        public bool Complete
        {
            get;
            set;
        }
    }
}
