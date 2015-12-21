using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// For Facebook, represents a user/page that can be posted to.
    /// </summary>
    
    public class FacebookProfile
    {
        /// <summary>
        /// the user or page id
        /// </summary>
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// the user or page name
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// whether this is a user or a page
        /// </summary>
        [JsonProperty("is_page")]
        public bool IsPage
        {
            get;
            set;
        }
    }
}
