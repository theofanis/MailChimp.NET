using Newtonsoft.Json;

namespace MailChimp.Helper
{
    
    public class VerifiedDomain
    {
        /// <summary>
        /// The verified domain
        /// </summary>
        [JsonProperty("domain")]
        public string Domain
        {
            get;
            set;
        }

        /// <summary>
        /// The status of the verification - either "verified" or "pending"
        /// </summary>
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        /// <summary>
        /// The email address used for verification - "pre-existing" if we automatically backfilled it at some point 
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }
    }
}
