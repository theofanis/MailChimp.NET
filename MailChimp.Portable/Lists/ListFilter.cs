using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Optional list filters
    /// </summary>
    
    public class ListFilter
    {
        /// <summary>
        /// optional - return a single list using a known list_id. Accepts 
        /// multiples separated by commas when not using exact matching
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only lists that match this name
        /// </summary>
        [JsonProperty("list_name")]
        public string ListName
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only lists that have a default from name matching this
        /// </summary>
        [JsonProperty("from_name")]
        public string FromName
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only lists that have a default from email matching this
        /// </summary>
        [JsonProperty("from_email")]
        public string FromEmail
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only lists that have a default from email matching this
        /// </summary>
        [JsonProperty("from_subject")]
        public string FromSubject
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show lists that were created before this date/time - 
        /// 24 hour format in GMT, eg "2013-12-30 20:30:00"
        /// </summary>
        [JsonProperty("created_before")]
        public string CreatedBefore
        {
            get;
            set;
        }

        /// <summary>
        /// optional - only show lists that were created since this date/time - 
        /// 24 hour format in GMT, eg "2013-12-30 20:30:00"
        /// </summary>
        [JsonProperty("created_after")]
        public string CreatedAfter
        {
            get;
            set;
        }

        /// <summary>
        /// optional - flag for whether to filter on exact values when filtering, 
        /// or search within content for filter values - defaults to true
        /// </summary>
        [JsonProperty("exact")]
        public bool? Exact
        {
            get;
            set;
        }
    }
}
