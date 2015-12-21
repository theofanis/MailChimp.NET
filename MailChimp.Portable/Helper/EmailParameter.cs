using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Describes an email parameter.  Failing to provide anything will 
    /// produce an error relating to the email address
    /// </summary>
    
    public class EmailParameter
    {
        /// <summary>
        /// an email address
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// the unique id for an email address (not list related) - 
        /// the email "id" returned from listMemberInfo, Webhooks, Campaigns, etc.
        /// </summary>
        [JsonProperty("euid")]
        public string EUId
        {
            get;
            set;
        }

        /// <summary>
        /// the list email id (previously called web_id) for a list-member-info 
        /// type call. this doesn't change when the email address changes
        /// </summary>
        [JsonProperty("leid")]
        public string LEId
        {
            get;
            set;
        }
    }
}
