using System.Collections.Generic;
using Newtonsoft.Json;
using MailChimp.Helper;

namespace MailChimp.Lists
{
    
    public class BatchSubscribeResult
    {
        /// <summary>
        /// Number of email addresses that were successfully added
        /// </summary>
        [JsonProperty("add_count")]
        public int AddCount
        {
            get;
            set;
        }

        /// <summary>
        /// Email addresses for each add
        /// </summary>
        [JsonProperty("adds")]
        public List<EmailParameter> Adds
        {
            get;
            set;
        }

        /// <summary>
        /// Number of email addresses that were successfully updated
        /// </summary>
        [JsonProperty("update_count")]
        public int UpdateCount
        {
            get;
            set;
        }

        /// <summary>
        /// Email addresses for each update
        /// </summary>
        [JsonProperty("updates")]
        public List<EmailParameter> Updates
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
        /// Error information
        /// </summary>
        [JsonProperty("errors")]
        public List<ListError> Errors
        {
            get;
            set;
        }
    }
}
