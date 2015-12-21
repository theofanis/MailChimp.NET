using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Geographic location information
    /// </summary>
    
    public class MCLocation
    {
        /// <summary>
        /// use the specified latitude (longitude must exist for this to work)
        /// </summary>
        [JsonProperty("latitude")]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// use the specified longitude (latitude must exist for this to work)
        /// </summary>
        [JsonProperty("longitude")]
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// if this (or any other key exists here) we'll try to use the optin ip. 
        /// NOTE - this will slow down each subscribe call a bit, especially for lat/lng pairs 
        /// in sparsely populated areas. Currently our automated background processes 
        /// can and will overwrite this based on opens and clicks.
        /// </summary>
        [JsonProperty("anything")]
        public string Anything
        {
            get;
            set;
        }
    }
}
