using Newtonsoft.Json;

namespace MailChimp.Users
{
    
    public class UserInvite
    {
        /// <summary>
        /// the email address the invitation was sent to
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// the role that will be assigned if they accept
        /// </summary>
        [JsonProperty("role")]
        public string Role
        {
            get;
            set;
        }

        /// <summary>
        /// the time the invitation was sent. this will change if it's resent.
        /// </summary>
        [JsonProperty("sent_at")]
        public string SentAt
        {
            get;
            set;
        }

        /// <summary>
        /// the expiration time for the invitation. this will change if it's resent.
        /// </summary>
        [JsonProperty("expiration")]
        public string Expiration
        {
            get;
            set;
        }

        /// <summary>
        /// the welcome message included with the invitation
        /// </summary>
        [JsonProperty("msg")]
        public string Message
        {
            get;
            set;
        }
    }
}
