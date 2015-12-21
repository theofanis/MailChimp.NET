using MailChimp.Helper;
using Newtonsoft.Json;

namespace MailChimp.Lists
{
    /// <summary>
    /// Error messages from batch subscribes
    /// </summary>
    
    public class ListError
    {
        /// <summary>
        /// whatever was passed in the batch record's email parameter
        /// </summary>
        [JsonProperty("email")]
        public EmailParameter Email
        {
            get;
            set;
        }

        /// <summary>
        /// the error code
        /// </summary>
        [JsonProperty("code")]
        public int ErrorCode
        {
            get;
            set;
        }

        /// <summary>
        /// the full error message
        /// </summary>
        [JsonProperty("error")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}
