using Newtonsoft.Json;

namespace MailChimp.Helper
{
    /// <summary>
    /// Message from 'Ping' call
    /// </summary>
    
    public class PingMessage
    {
        /// <summary>
        /// containing "Everything's Chimpy!" if everything is chimpy, otherwise returns an error message
        /// </summary>
        [JsonProperty("msg")]
        public string Message
        {
            get;
            set;
        }
    }
}
