using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Provides information about a Mailchimp addon module
    /// </summary>
    
    public class Module
    {
        /// <summary>
        /// An internal module id
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// The module name
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// The date the module was added
        /// </summary>
        [JsonProperty("added")]
        public string Added
        {
            get;
            set;
        }

        /// <summary>
        /// Any extra data associated with this module as key=>value pairs
        /// </summary>
        [JsonProperty("data")]
        public Dictionary<string, string> Data
        {
            get;
            set;
        }
    }
}
