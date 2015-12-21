using Newtonsoft.Json;

namespace MailChimp.Errors
{
    /// <summary>
    /// Class for API error information from the Mailchimp API
    /// </summary>
    
    public class ApiError
    {
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }

        [JsonProperty("code")]
        public string Code
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("error")]
        public string Error
        {
            get;
            set;
        }
    }
}
