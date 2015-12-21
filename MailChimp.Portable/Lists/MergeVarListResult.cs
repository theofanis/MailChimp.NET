using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class MergeVarListResult
    {
        /// <summary>
        /// The list id 
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// the list name 
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// list of each merge var 
        /// </summary>
        [JsonProperty("merge_vars")]
        public List<MergeVarItemResult> MergeVars
        {
            get;
            set;
        }
    }
}
