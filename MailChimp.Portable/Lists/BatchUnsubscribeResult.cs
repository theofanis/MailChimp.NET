using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// The results of a batch unsubscribe
    /// </summary>
    
    public class BatchUnsubscribeResult
    {
        /// <summary>
        /// Number of email addresses that were successfully removed
        /// </summary>
        [JsonProperty("success_count")]
        public int SuccessCount
        {
            get;
            set;
        }

        /// <summary>
        /// Number of email addresses that failed during addition/updating
        /// </summary>
        [JsonProperty("error_count")]
        public int ErrorCount
        {
            get;
            set;
        }

        /// <summary>
        /// List of errors encountered
        /// </summary>
        [JsonProperty("errors")]
        public List<ListError> Errors
        {
            get;
            set;
        }
    }
}
