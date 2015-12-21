using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MergeVarResult
    {
        /// <summary>
        /// The number of subscribers successfully found on the list
        /// </summary>
        [JsonProperty("success_count")]
        public int SuccessCount
        {
            get;
            set;
        }

        /// <summary>
        /// The number of subscribers who were not found on the list
        /// </summary>
        [JsonProperty("error_count")]
        public int ErrorCount
        {
            get;
            set;
        }

        /// <summary>
        ///LList of each merge var
        /// </summary>
        [JsonProperty("data")]
        public List<MergeVarListResult> Data
        {
            get;
            set;
        }

        /// <summary>
        /// List of errors
        /// </summary>
        [JsonProperty("errors")]
        public List<MergeVarError> Errors
        {
            get;
            set;
        }
    }
}
