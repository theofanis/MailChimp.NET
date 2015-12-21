using Newtonsoft.Json;

namespace MailChimp.Users
{
    
    public class UserActionResult
    {
        /// <summary>
        /// The status (success) of the call if it completed. 
        /// Otherwise an error is thrown.
        /// </summary>
        [JsonProperty("status")]
        public string Status
        {
            get;
            set;
        }
    }
}
