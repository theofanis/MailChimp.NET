using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Describes a list that a member is subscribed to
    /// </summary>
    
    public class ListForEmail
    {
        /// <summary>
        /// the list unique id
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// id referenced in web interface urls
        /// </summary>
        [JsonProperty("web_id")]
        public string WebId
        {
            get;
            set;
        }

        /// <summary>
        /// list name
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
    }
}
