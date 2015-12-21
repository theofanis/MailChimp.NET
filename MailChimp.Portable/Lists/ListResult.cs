using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// result of the operation including valid data and any errors
    /// </summary>
    
    public class ListResult
    {
        /// <summary>
        /// the total number of lists which matched the provided filters
        /// </summary>
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }

        /// <summary>
        /// lists which matched the provided filters
        /// </summary>
        [JsonProperty("data")]
        public List<ListInfo> Data
        {
            get;
            set;
        }
    }
}
