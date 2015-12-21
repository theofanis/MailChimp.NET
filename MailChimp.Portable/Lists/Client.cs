using Newtonsoft.Json;

namespace MailChimp.Lists
{
    
    public class Client
    {
        /// <summary>
        /// the common name of the client
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// a url representing a path to an icon representing this client
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconURL
        {
            get;
            set;
        }
    }
}
