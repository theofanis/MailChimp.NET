using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Class to represent each connected integration that can be used with campaigns
    /// </summary>
    
    public class Integration
    {
        /// <summary>
        /// an internal id for the integration
        /// </summary>
        [JsonProperty("id")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// the integration name
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// either "_any_" when globally accessible or the list id it's valid for use against
        /// </summary>
        [JsonProperty("list_id")]
        public string ListId
        {
            get;
            set;
        }

        /// <summary>
        /// if applicable, the user id for the integrated system
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// if applicable, the user/account name for the integrated system
        /// </summary>
        [JsonProperty("account")]
        public string Account
        {
            get;
            set;
        }

        /// <summary>
        /// For Facebook, users/pages that can be posted to
        /// </summary>
        [JsonProperty("profiles")]
        public List<FacebookProfile> Profiles
        {
            get;
            set;
        }
    }
}
