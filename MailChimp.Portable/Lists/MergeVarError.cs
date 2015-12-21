using Newtonsoft.Json;

namespace MailChimp.Lists
{
    public class MergeVarError
    {
        /// <summary>
        /// the passed list id that failed 
        /// </summary>
        [JsonProperty("id")]
        public string Id
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
        [JsonProperty("msg")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}
